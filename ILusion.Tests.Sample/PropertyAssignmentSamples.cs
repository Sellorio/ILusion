namespace ILusion.Tests.Sample
{
    public class PropertyAssignmentSamplesBase
    {
        public virtual string BaseProperty { set { } }
    }

    public class PropertyAssignmentSamples : PropertyAssignmentSamplesBase
    {
        public string InstanceAutoProperty { get; set; }
        public string InstanceSetProperty { set { } }
        public virtual string InstanceVirtualAutoProperty { get; set; }
        public virtual string InstanceVirtualSetProperty { set { } }
        public static string StaticAutoProperty { get; set; }
        public static string StaticSetProperty { set { } }

        public override string BaseProperty
        {
            set { base.BaseProperty = value; }
        }

        public void SetInstanceAutoProperty()
        {
            InstanceAutoProperty = "";
        }

        public void SetInstanceSetProperty()
        {
            InstanceSetProperty = "";
        }

        public void SetInstanceVirtualAutoProperty()
        {
            InstanceVirtualAutoProperty = "";
        }

        public void SetInstanceVirtualSetProperty()
        {
            InstanceVirtualSetProperty = "";
        }

        public void SetStaticAutoProperty()
        {
            StaticAutoProperty = "";
        }

        public void SetStaticSetProperty()
        {
            StaticSetProperty = "";
        }
    }

    public interface IPropertyAssignmentHasProp
    {
        string Prop { set; }
    }

    public struct PropertyAssignmentSamplesStruct
    {
        public string InstanceAutoProperty { get; set; }

        public void SetInstanceAutoPropertyStruct()
        {
            InstanceAutoProperty = "";
        }

        public void SetInstanceAutoPropertyOnObject(PropertyAssignmentSamples target)
        {
            target.InstanceAutoProperty = "";
        }

        public void SetInstanceVirtualAutoPropertyOnObject(PropertyAssignmentSamples target)
        {
            target.InstanceVirtualAutoProperty = "";
        }
    }

    public static class GenericPropertyAssignmentSamples<T>
        where T : IPropertyAssignmentHasProp
    {
        public static string Property { set { } }

        public static void ConstrainedSet(T param)
        {
            param.Prop = "";
        }

        public static void SetPropertyFromGeneric()
        {
            Property = "";
        }
    }
}
