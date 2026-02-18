using System.ComponentModel.DataAnnotations.Schema;
using StudentAnalytics.Enums;
namespace StudentAnalytics.Models;

public partial class Student
{
    [NotMapped]
    public GenderType GenderEnum
    {
        get => Enum.Parse<GenderType>(Gender, true);
        set => Gender = value.ToString().ToLower();
    }
}