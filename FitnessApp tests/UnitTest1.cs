using FitnessApp1;

namespace FitnessApp_tests;

public class UnitTest1
{
    [Theory]
    [InlineData(56, 22.0472)]
    [InlineData(66, 25.9842)]
    [InlineData(30, 11.811)]
    [InlineData(0, 0)]

    //Test to make sure our conversion from cm to inches works 0.3937m
    //Red-Green test process-fails first, then passes if code is written correctly
    //Red check-failed all with throw new NotImplementedException()
    //Green check-passed with code block written
    public void MetricToImperialTest(decimal cm, decimal expected)
    {
        //Arrange
        var conversion = new Conversion();
        //Act
        var actual = conversion.MetricToImperial(cm);
        //Assert
        Assert.Equal(expected, actual);
    }
}