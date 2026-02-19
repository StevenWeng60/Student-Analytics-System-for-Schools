using System.ComponentModel.DataAnnotations.Schema;
using StudentAnalytics.Enums;
namespace StudentAnalytics.Models;

public partial class User
{
    [NotMapped]
    public UserTypeEnumVar UserTypeEnum
    {
        get => Enum.Parse<UserTypeEnumVar>(UserType, true);
        set => UserType = value.ToString().ToLower();
    }
}