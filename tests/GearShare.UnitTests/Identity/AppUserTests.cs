using GearShare.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using GearShare.Application.Entities;

namespace GearShare.UnitTests.Identity;

public class AppUserTests
{
    [Fact]
    public void New_user_defaults_to_active_member()
    {
        var user = new AppUser();
        Assert.Equal(UserRole.Member, user.Role);
        Assert.Equal(UserStatus.Active, user.Status);
        Assert.Null(user.SuspensionReason);
    }

    [Fact]
    public void Email_is_trimmed()
    {
        var user = new AppUser { Email = "  alice@example.com  " };
        Assert.Equal("alice@example.com", user.Email);
    }

    [Theory]
    [InlineData("  Alice@Example.com ", "ALICE@EXAMPLE.COM")]
    [InlineData("alice@example.com", "ALICE@EXAMPLE.COM")]
    public void Normalizer_trims_and_ignores_case(string input, string expected)
    {
        var normalizer = new TrimmedUpperLookupNormalizer();
        Assert.Equal(expected, normalizer.NormalizeEmail(input));
    }

    [Fact]
    public void Passwords_are_hashed_not_stored_plain()
    {
        var hasher = new PasswordHasher<AppUser>();
        var user = new AppUser();
        var hash = hasher.HashPassword(user, "Pa55word!");

        Assert.NotEqual("Pa55word!", hash);
        Assert.Equal(PasswordVerificationResult.Success,
            hasher.VerifyHashedPassword(user, hash, "Pa55word!"));
    }
}