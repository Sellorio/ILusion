using ILusion.Methods;
using ILusion.Methods.LogicTrees.Nodes;
using ILusion.Tests.Sample;
using Xunit;

namespace ILusion.Tests
{
    public class CastTests : TestBase
    {
        // BoxStruct
        // UnboxStruct
        // BoxGeneric
        // UnboxGeneric
        // CastClassToObject
        // CastObjectToClass
        // CastGenericOfTypeToType
        // CastTypeToGenericOfType
        // Other....

        [Fact]
        public void Int8ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToUInt8));
        }

        [Fact]
        public void Int8ToInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int8ToInt16));
        }

        [Fact]
        public void Int8ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToUInt16));
        }

        [Fact]
        public void Int8ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int8ToInt32));
        }

        [Fact]
        public void Int8ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int8ToUInt32));
        }

        [Fact]
        public void Int8ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToInt64));
        }

        [Fact]
        public void Int8ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToUInt64));
        }

        [Fact]
        public void Int8ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToFloat));
        }

        [Fact]
        public void Int8ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.Int8ToDouble));
        }

        [Fact]
        public void UInt8ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt8ToInt8));
        }

        [Fact]
        public void UInt8ToInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt8ToInt16));
        }

        [Fact]
        public void UInt8ToUInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt8ToUInt16));
        }

        [Fact]
        public void UInt8ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt8ToInt32));
        }

        [Fact]
        public void UInt8ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt8ToUInt32));
        }

        [Fact]
        public void UInt8ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt8ToInt64));
        }

        [Fact]
        public void UInt8ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt8ToUInt64));
        }

        [Fact]
        public void UInt8ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.UInt8ToFloat));
        }

        [Fact]
        public void UInt8ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.UInt8ToDouble));
        }

        [Fact]
        public void Int16ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToInt8));
        }

        [Fact]
        public void Int16ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToUInt8));
        }

        [Fact]
        public void Int16ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToUInt16));
        }

        [Fact]
        public void Int16ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int16ToInt32));
        }

        [Fact]
        public void Int16ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int16ToUInt32));
        }

        [Fact]
        public void Int16ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToInt64));
        }

        [Fact]
        public void Int16ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToUInt64));
        }

        [Fact]
        public void Int16ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToFloat));
        }

        [Fact]
        public void Int16ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.Int16ToDouble));
        }

        [Fact]
        public void UInt16ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToInt8));
        }

        [Fact]
        public void UInt16ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToUInt8));
        }

        [Fact]
        public void UInt16ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToInt16));
        }

        [Fact]
        public void UInt16ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt16ToInt32));
        }

        [Fact]
        public void UInt16ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt16ToUInt32));
        }

        [Fact]
        public void UInt16ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToInt64));
        }

        [Fact]
        public void UInt16ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToUInt64));
        }

        [Fact]
        public void UInt16ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToFloat));
        }

        [Fact]
        public void UInt16ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.UInt16ToDouble));
        }

        [Fact]
        public void Int32ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToInt8));
        }

        [Fact]
        public void Int32ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToUInt8));
        }

        [Fact]
        public void Int32ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToInt16));
        }

        [Fact]
        public void Int32ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToUInt16));
        }

        [Fact]
        public void Int32ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int32ToUInt32));
        }

        [Fact]
        public void Int32ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToInt64));
        }

        [Fact]
        public void Int32ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToUInt64));
        }

        [Fact]
        public void Int32ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToFloat));
        }

        [Fact]
        public void Int32ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.Int32ToDouble));
        }

        [Fact]
        public void UInt32ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToInt8));
        }

        [Fact]
        public void UInt32ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToUInt8));
        }

        [Fact]
        public void UInt32ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToInt16));
        }

        [Fact]
        public void UInt32ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToUInt16));
        }

        [Fact]
        public void UInt32ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt32ToInt32));
        }

        [Fact]
        public void UInt32ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToInt64));
        }

        [Fact]
        public void UInt32ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToUInt64));
        }

        [Fact]
        public void UInt32ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToFloat));
        }

        [Fact]
        public void UInt32ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.UInt32ToDouble));
        }

        [Fact]
        public void Int64ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToInt8));
        }

        [Fact]
        public void Int64ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToUInt8));
        }

        [Fact]
        public void Int64ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToInt16));
        }

        [Fact]
        public void Int64ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToUInt16));
        }

        [Fact]
        public void Int64ToInt32()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToInt32));
        }

        [Fact]
        public void Int64ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToUInt32));
        }

        [Fact]
        public void Int64ToUInt64()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.Int64ToUInt64));
        }

        [Fact]
        public void Int64ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToFloat));
        }

        [Fact]
        public void Int64ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.Int64ToDouble));
        }

        [Fact]
        public void UInt64ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToInt8));
        }

        [Fact]
        public void UInt64ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToUInt8));
        }

        [Fact]
        public void UInt64ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToInt16));
        }

        [Fact]
        public void UInt64ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToUInt16));
        }

        [Fact]
        public void UInt64ToInt32()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToInt32));
        }

        [Fact]
        public void UInt64ToInt64()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.UInt64ToInt64));
        }

        [Fact]
        public void UInt64ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToUInt32));
        }

        [Fact]
        public void UInt64ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToFloat));
        }

        [Fact]
        public void UInt64ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.UInt64ToDouble));
        }

        [Fact]
        public void DoubleToInt8()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToInt8));
        }

        [Fact]
        public void DoubleToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToUInt8));
        }

        [Fact]
        public void DoubleToInt16()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToInt16));
        }

        [Fact]
        public void DoubleToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToUInt16));
        }

        [Fact]
        public void DoubleToInt32()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToInt32));
        }

        [Fact]
        public void DoubleToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToUInt32));
        }

        [Fact]
        public void DoubleToInt64()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToInt64));
        }

        [Fact]
        public void DoubleToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToUInt64));
        }

        [Fact]
        public void DoubleToFloat()
        {
            NumericConversionTest(nameof(CastSamples.DoubleToFloat));
        }

        [Fact]
        public void FloatToInt8()
        {
            NumericConversionTest(nameof(CastSamples.FloatToInt8));
        }

        [Fact]
        public void FloatToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.FloatToUInt8));
        }

        [Fact]
        public void FloatToInt16()
        {
            NumericConversionTest(nameof(CastSamples.FloatToInt16));
        }

        [Fact]
        public void FloatToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.FloatToUInt16));
        }

        [Fact]
        public void FloatToInt32()
        {
            NumericConversionTest(nameof(CastSamples.FloatToInt32));
        }

        [Fact]
        public void FloatToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.FloatToUInt32));
        }

        [Fact]
        public void FloatToInt64()
        {
            NumericConversionTest(nameof(CastSamples.FloatToInt64));
        }

        [Fact]
        public void FloatToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.FloatToUInt64));
        }

        [Fact]
        public void FloatToDouble()
        {
            NumericConversionTest(nameof(CastSamples.FloatToDouble));
        }

        [Fact]
        public void CheckedInt8ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToUInt8));
        }

        [Fact]
        public void CheckedInt8ToInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedInt8ToInt16));
        }

        [Fact]
        public void CheckedInt8ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToUInt16));
        }

        [Fact]
        public void CheckedInt8ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedInt8ToInt32));
        }

        [Fact]
        public void CheckedInt8ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToUInt32));
        }

        [Fact]
        public void CheckedInt8ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToInt64));
        }

        [Fact]
        public void CheckedInt8ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToUInt64));
        }

        [Fact]
        public void CheckedInt8ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToFloat));
        }

        [Fact]
        public void CheckedInt8ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt8ToDouble));
        }

        [Fact]
        public void CheckedUInt8ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt8ToInt8));
        }

        [Fact]
        public void CheckedUInt8ToInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt8ToInt16));
        }

        [Fact]
        public void CheckedUInt8ToUInt16()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt8ToUInt16));
        }

        [Fact]
        public void CheckedUInt8ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt8ToInt32));
        }

        [Fact]
        public void CheckedUInt8ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt8ToUInt32));
        }

        [Fact]
        public void CheckedUInt8ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt8ToInt64));
        }

        [Fact]
        public void CheckedUInt8ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt8ToUInt64));
        }

        [Fact]
        public void CheckedUInt8ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt8ToFloat));
        }

        [Fact]
        public void CheckedUInt8ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt8ToDouble));
        }

        [Fact]
        public void CheckedInt16ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToInt8));
        }

        [Fact]
        public void CheckedInt16ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToUInt8));
        }

        [Fact]
        public void CheckedInt16ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToUInt16));
        }

        [Fact]
        public void CheckedInt16ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedInt16ToInt32));
        }

        [Fact]
        public void CheckedInt16ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToUInt32));
        }

        [Fact]
        public void CheckedInt16ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToInt64));
        }

        [Fact]
        public void CheckedInt16ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToUInt64));
        }

        [Fact]
        public void CheckedInt16ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToFloat));
        }

        [Fact]
        public void CheckedInt16ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt16ToDouble));
        }

        [Fact]
        public void CheckedUInt16ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToInt8));
        }

        [Fact]
        public void CheckedUInt16ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToUInt8));
        }

        [Fact]
        public void CheckedUInt16ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToInt16));
        }

        [Fact]
        public void CheckedUInt16ToInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt16ToInt32));
        }

        [Fact]
        public void CheckedUInt16ToUInt32()
        {
            IgnoredNumericConversionTest(nameof(CastSamples.CheckedUInt16ToUInt32));
        }

        [Fact]
        public void CheckedUInt16ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToInt64));
        }

        [Fact]
        public void CheckedUInt16ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToUInt64));
        }

        [Fact]
        public void CheckedUInt16ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToFloat));
        }

        [Fact]
        public void CheckedUInt16ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt16ToDouble));
        }

        [Fact]
        public void CheckedInt32ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToInt8));
        }

        [Fact]
        public void CheckedInt32ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToUInt8));
        }

        [Fact]
        public void CheckedInt32ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToInt16));
        }

        [Fact]
        public void CheckedInt32ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToUInt16));
        }

        [Fact]
        public void CheckedInt32ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToUInt32));
        }

        [Fact]
        public void CheckedInt32ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToInt64));
        }

        [Fact]
        public void CheckedInt32ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToUInt64));
        }

        [Fact]
        public void CheckedInt32ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToFloat));
        }

        [Fact]
        public void CheckedInt32ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt32ToDouble));
        }

        [Fact]
        public void CheckedUInt32ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToInt8));
        }

        [Fact]
        public void CheckedUInt32ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToUInt8));
        }

        [Fact]
        public void CheckedUInt32ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToInt16));
        }

        [Fact]
        public void CheckedUInt32ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToUInt16));
        }

        [Fact]
        public void CheckedUInt32ToInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToInt32));
        }

        [Fact]
        public void CheckedUInt32ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToInt64));
        }

        [Fact]
        public void CheckedUInt32ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToUInt64));
        }

        [Fact]
        public void CheckedUInt32ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToFloat));
        }

        [Fact]
        public void CheckedUInt32ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt32ToDouble));
        }

        [Fact]
        public void CheckedInt64ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToInt8));
        }

        [Fact]
        public void CheckedInt64ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToUInt8));
        }

        [Fact]
        public void CheckedInt64ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToInt16));
        }

        [Fact]
        public void CheckedInt64ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToUInt16));
        }

        [Fact]
        public void CheckedInt64ToInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToInt32));
        }

        [Fact]
        public void CheckedInt64ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToUInt32));
        }

        [Fact]
        public void CheckedInt64ToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToUInt64));
        }

        [Fact]
        public void CheckedInt64ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToFloat));
        }

        [Fact]
        public void CheckedInt64ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedInt64ToDouble));
        }

        [Fact]
        public void CheckedUInt64ToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToInt8));
        }

        [Fact]
        public void CheckedUInt64ToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToUInt8));
        }

        [Fact]
        public void CheckedUInt64ToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToInt16));
        }

        [Fact]
        public void CheckedUInt64ToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToUInt16));
        }

        [Fact]
        public void CheckedUInt64ToInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToInt32));
        }

        [Fact]
        public void CheckedUInt64ToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToInt64));
        }

        [Fact]
        public void CheckedUInt64ToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToUInt32));
        }

        [Fact]
        public void CheckedUInt64ToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToFloat));
        }

        [Fact]
        public void CheckedUInt64ToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedUInt64ToDouble));
        }

        [Fact]
        public void CheckedDoubleToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToInt8));
        }

        [Fact]
        public void CheckedDoubleToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToUInt8));
        }

        [Fact]
        public void CheckedDoubleToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToInt16));
        }

        [Fact]
        public void CheckedDoubleToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToUInt16));
        }

        [Fact]
        public void CheckedDoubleToInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToInt32));
        }

        [Fact]
        public void CheckedDoubleToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToUInt32));
        }

        [Fact]
        public void CheckedDoubleToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToInt64));
        }

        [Fact]
        public void CheckedDoubleToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToUInt64));
        }

        [Fact]
        public void CheckedDoubleToFloat()
        {
            NumericConversionTest(nameof(CastSamples.CheckedDoubleToFloat));
        }

        [Fact]
        public void CheckedFloatToInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToInt8));
        }

        [Fact]
        public void CheckedFloatToUInt8()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToUInt8));
        }

        [Fact]
        public void CheckedFloatToInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToInt16));
        }

        [Fact]
        public void CheckedFloatToUInt16()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToUInt16));
        }

        [Fact]
        public void CheckedFloatToInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToInt32));
        }

        [Fact]
        public void CheckedFloatToUInt32()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToUInt32));
        }

        [Fact]
        public void CheckedFloatToInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToInt64));
        }

        [Fact]
        public void CheckedFloatToUInt64()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToUInt64));
        }

        [Fact]
        public void CheckedFloatToDouble()
        {
            NumericConversionTest(nameof(CastSamples.CheckedFloatToDouble));
        }

        private void NumericConversionTest(string methodName)
        {
            var sampleMethod = GetSampleMethod(nameof(CastSamples), methodName);
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x =>
                {
                    CheckNode<VariableAssignmentNode>(
                        x,
                        y =>
                        {
                            var cast =
                                CheckNode<CastNode>(
                                    y,
                                    z => CheckNode<ParameterNode>(z));
                        });
                },
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }

        private void IgnoredNumericConversionTest(string methodName)
        {
            var sampleMethod = GetSampleMethod(nameof(CastSamples), methodName);
            var syntaxTree = SyntaxTree.FromMethodDefinition(sampleMethod);

            CheckStatements(
                syntaxTree,
                x => CheckNode<VariableAssignmentNode>(x, y => CheckNode<ParameterNode>(y)),
                CheckReturn());

            EmitAndValidateUnchanged(sampleMethod, syntaxTree);
        }
    }
}
