using System.ComponentModel.DataAnnotations.Schema;
using StudentAnalytics.Enums;
namespace StudentAnalytics.Models;

public partial class Class
{
    [NotMapped]
    public SubjectType SubjectTypeEnum
    {
        get => Enum.Parse<SubjectType>(Subject, true);
        set => Subject = value.ToString().ToLower();
    }
}