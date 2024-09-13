using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Tests.UnitTests.Helpers;

public class GenerateDefaultTestData : AutoDataAttribute
{
    public GenerateDefaultTestData() : base(GetDefaultFixture)
    {
    }

    public static IFixture GetDefaultFixture()
    {
        AutoMoqCustomization autoMoqCustomization = new();

        return new Fixture()
              .Customize(autoMoqCustomization);
    }
}