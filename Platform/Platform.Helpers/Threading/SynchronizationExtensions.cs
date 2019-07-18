﻿using System;

namespace Platform.Helpers.Threading
{
    /// <remarks>
    /// TODO: Избавиться от анонимных функций передаваемых в ExecuteReadOperation и ExecureWriteOperation
    /// </remarks>
    public static class SynchronizationExtensions
    {
        public static TResult ExecuteReadOperation<TResult, TParam>(this ISynchronization synchronization, TParam parameter, Func<TParam, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter));
        public static void ExecuteReadOperation<TParam>(this ISynchronization synchronization, TParam parameter, Action<TParam> action) => synchronization.ExecuteReadOperation(() => action(parameter));
        public static TResult ExecuteWriteOperation<TResult, TParam>(this ISynchronization synchronization, TParam parameter, Func<TParam, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter));
        public static void ExecuteWriteOperation<TParam>(this ISynchronization synchronization, TParam parameter, Action<TParam> action) => synchronization.ExecuteWriteOperation(() => action(parameter));
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2));
        public static void ExecuteReadOperation<TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Action<TParam1, TParam2> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2));
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Func<TParam1, TParam2, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2));
        public static void ExecuteWriteOperation<TParam1, TParam2>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, Action<TParam1, TParam2> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2));
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2, parameter3));
        public static void ExecuteReadOperation<TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Action<TParam1, TParam2, TParam3> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2, parameter3));
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Func<TParam1, TParam2, TParam3, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2, parameter3));
        public static void ExecuteWriteOperation<TParam1, TParam2, TParam3>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, Action<TParam1, TParam2, TParam3> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2, parameter3));
        public static TResult ExecuteReadOperation<TResult, TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) => synchronization.ExecuteReadOperation(() => function(parameter1, parameter2, parameter3, parameter4));
        public static void ExecuteReadOperation<TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Action<TParam1, TParam2, TParam3, TParam4> action) => synchronization.ExecuteReadOperation(() => action(parameter1, parameter2, parameter3, parameter4));
        public static TResult ExecuteWriteOperation<TResult, TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Func<TParam1, TParam2, TParam3, TParam4, TResult> function) => synchronization.ExecuteWriteOperation(() => function(parameter1, parameter2, parameter3, parameter4));
        public static void ExecuteWriteOperation<TParam1, TParam2, TParam3, TParam4>(this ISynchronization synchronization, TParam1 parameter1, TParam2 parameter2, TParam3 parameter3, TParam4 parameter4, Action<TParam1, TParam2, TParam3, TParam4> action) => synchronization.ExecuteWriteOperation(() => action(parameter1, parameter2, parameter3, parameter4));
    }
}
