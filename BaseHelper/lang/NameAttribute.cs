using System;
using System.ComponentModel;
using System.Resources;

namespace BaseHelper.lang
{
    /// <summary>
    /// 名称特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class NameAttribute : DisplayNameAttribute
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public NameAttribute()
        {

        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public NameAttribute(string name) : base(name)
        {
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public NameAttribute(Type resourceType, string name)
        {
            ResourceManager rm = new ResourceManager(resourceType);
            base.DisplayNameValue = rm.GetString(name);
        }
    }
}
