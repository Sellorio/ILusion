namespace ILusion.Tests.Sample
{
    public class PropertySamplesBase
    {
        public virtual string BaseProperty { get; }
    }

    public class PropertySamples : PropertySamplesBase
    {
        public string InstanceAutoProperty { get; set; }
        public string InstanceGetProperty { get; }
        public virtual string InstanceVirtualAutoProperty { get; set; }
        public virtual string InstanceVirtualGetProperty { get; }
        public static string StaticAutoProperty { get; set; }
        public static string StaticGetProperty { get; }

        public override string BaseProperty
        {
            get => base.BaseProperty;
        }

        public void GetInstanceAutoProperty()
        {
            var x = InstanceAutoProperty;
        }

        public void GetInstanceGetProperty()
        {
            var x = InstanceGetProperty;
        }

        public void GetInstanceVirtualAutoProperty()
        {
            var x = InstanceVirtualAutoProperty;
        }

        public void GetInstanceVirtualGetProperty()
        {
            var x = InstanceVirtualGetProperty;
        }

        public void GetStaticAutoProperty()
        {
            var x = StaticAutoProperty;
        }

        public void GetStaticGetProperty()
        {
            var x = StaticGetProperty;
        }
    }

    public struct PropertySamplesStruct
    {
        public string InstanceAutoProperty { get; set; }

        public void GetInstanceAutoPropertyStruct()
        {
            var x = InstanceAutoProperty;
        }

        public void GetInstanceAutoPropertyOnObject(PropertySamples target)
        {
            var x = target.InstanceAutoProperty;
        }

        public void GetInstanceVirtualAutoPropertyOnObject(PropertySamples target)
        {
            var x = target.InstanceVirtualAutoProperty;
        }
    }

    public interface IHasProp
    {
        string Prop { get; }
    }

    public static class GenericPropertySamples<T>
        where T : IHasProp
    {
        public static string Property { get; }

        public static void ConstrainedGet(T param)
        {
            var x = param.Prop;
        }

        public static void GetPropertyFromGeneric()
        {
            var x = Property;
        }
    }
}
