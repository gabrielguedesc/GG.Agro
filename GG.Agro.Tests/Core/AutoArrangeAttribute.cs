using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace GG.Agro.Tests.Core
{
    public class AutoArrangeAttribute : AutoDataAttribute
    {
        private static Fixture CreateCustomFixture()
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization())
                   .Inject(new Bogus.Faker());

            return fixture;
        }

        public AutoArrangeAttribute()
            : base(() => CreateCustomFixture()) { }
    }
}
