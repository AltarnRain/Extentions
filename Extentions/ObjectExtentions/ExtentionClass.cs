// <copyright file="ExtentionClass.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Extentions
{
    using System;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Casts an object to Type T.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="obj">Any class </param>
        /// <returns>Class cast to T</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            var castedObject = obj as T;
            if (castedObject == null)
            {
                throw new InvalidCastException("Cannot perform cast");
            }

            return castedObject;
        }
    }
}
