using System;
using System.Reflection;
using System.Resources;

namespace ProEasyUI
{
    public class I18n : ResourceManager
    {
        public I18n(string path) : base(path, Assembly.GetExecutingAssembly())
        {
        }

        public override string GetString(string name)
        {
            try
            {
                return base.GetString(name) != null ? base.GetString(name) : name;
            }
            catch (Exception)
            {
                return name;
            }
        }
    }
}
