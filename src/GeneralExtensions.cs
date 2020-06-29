using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

#if !NET35
using System.Threading.Tasks;
#endif

namespace LiteLoader
{
    public static class GeneralExtensions
    {
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable CA1825 // Avoid zero-length array allocations.
        private static readonly object[] EmptyArray = new object[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations.
#pragma warning restore IDE0052 // Remove unread private members

        public static bool HasMatchingSignature(this MethodBase method, Type[] parameterTypes, bool strict = false)
        {
            if (parameterTypes == null)
            {
                return true;
            }

            ParameterInfo[] parameters = method.GetParameters();

            if (parameterTypes.Length != parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < parameterTypes.Length; i++)
            {
                Type pt = parameters[i].ParameterType;
                Type at = parameterTypes[i];

                if (!strict)
                {
                    if (!pt.IsAssignableFrom(at))
                    {
                        return false;
                    }
                }
                else
                {
                    if (pt != at)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool HasMatchingSignature(this MethodInfo method, Type[] parameterTypes, Type returnType, bool strict = false)
        {
            if (returnType != null)
            {
                if (strict)
                {
                    if (method.ReturnType != returnType)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!method.ReturnType.IsAssignableFrom(returnType))
                    {
                        return false;
                    }
                }
            }

            return method.HasMatchingSignature(parameterTypes, strict);
        }
        
        public static FileInfo CopyToTempPath(this FileInfo sourceFile)
        {
            if (sourceFile == null)
            {
                throw new ArgumentNullException(nameof(sourceFile));
            }

            FileInfo tempFile = new FileInfo(Path.GetTempFileName());
            return sourceFile.CopyToTempPath(tempFile);
        }

        public static FileInfo CopyToTempPath(this FileInfo sourceFile, FileInfo tempFile)
        {
            if (sourceFile == null)
            {
                throw new ArgumentNullException(nameof(sourceFile));
            }

            try
            {
                using (Stream temp = tempFile.OpenWrite())
                using (Stream source = sourceFile.OpenRead())
                {
                    byte[] buffer = new byte[256];

                    int position = 0;
                    while(true)
                    {
                        int length = source.Read(buffer, position, buffer.Length);
                        
                        if (length == 0)
                        {
                            break;
                        }

                        temp.Write(buffer, position, length);
                    }
                }

                tempFile.Refresh();
                return tempFile;
            }
            catch (Exception)
            {
                tempFile.Delete();
                throw;
            }
        }

#if !NET35

        private static readonly Type _taskType = typeof(Task);

        /// <summary>
        /// Attempts to await a result
        /// </summary>
        /// <remarks>This will work with recursivly with embeded tasks</remarks>
        /// <param name="task">The task to await the result of</param>
        /// <param name="timeout">The amount of time to wait before terminating the task</param>
        /// <param name="token">The cancelation token used to cancel this function</param>
        /// <returns>
        /// Returns the value of all processed tasks or DBNull.Value if there is no result
        /// </returns>
        public static object AwaitResult(this Task task, int timeout = 500, CancellationToken token = default)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (token == default)
            {
                token = CancellationToken.None;
            }

            Type taskType = task.GetType();

            if (!task.IsCompleted && task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            if (!taskType.IsGenericType)
            {
                return DBNull.Value;
            }

            int startTime = Environment.TickCount;
            task.Wait(timeout, token);
            int endTime = Environment.TickCount;
            timeout -= endTime - startTime;

            if (!task.IsCompleted)
            {
                return DBNull.Value;
            }

            MethodInfo resultMethod = taskType.GetProperty("Result", BindingFlags.Public | BindingFlags.Instance).GetMethod;
            object value = resultMethod.Invoke(task, EmptyArray);

            if (task.Exception != null)
            {
                throw task.Exception;
            }

            if (value != null && _taskType.IsInstanceOfType(value))
            {
                value = AwaitResult((Task)value, timeout, token);
            }

            return value;
        }
#endif
    }
}
