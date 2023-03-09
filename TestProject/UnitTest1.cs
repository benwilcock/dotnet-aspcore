namespace TestProject;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(false); //causing a test failure here to deliberately halt the supply chain
    }
    
}