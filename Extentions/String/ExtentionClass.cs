﻿// <copyright file="ExtentionClass.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Extentions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Deserializes the specified XML string.
        /// </summary>
        /// <typeparam name="T">An class</typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>Object of type T</returns>
        /// <exception cref="InvalidCastException">Invalid model cast</exception>
        /// <exception cref="Exception">An error occurred</exception>
        public static T Deserialize<T>(this string xmlString)
                  where T : class
        {
            if (xmlString == null)
            {
                return null;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringReader = new StringReader(xmlString);

                using (var reader = XmlReader.Create(stringReader))
                {
                    var returnValue = xmlserializer.Deserialize(reader) as T;

                    if (returnValue == null)
                    {
                        throw new InvalidCastException("Invalid model cast");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// Formats the specified strings.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>
        /// A formatted string
        /// </returns>
        public static string FormatString(this string str, params object[] objects)
        {
            var stringList = objects.Select(o => o.ToString());
            return string.Format(str, stringList.ToArray());
        }
    }
}
