using Xunit;
using FluentAssertions;
using System.Collections.ObjectModel;
using GroupProject_4047_4036.Model;

public class UnitTest1
{
    [Fact]
    public void CalcGPA_WithoutModules_ShouldReturnZero()
    {
        // Arrange
        var student = new Student();

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().Be(0.0);
    }

    [Fact]
    public void CalcGPA_WithValidModules_ShouldCalculateGpa()
    {
        // Arrange
        var student = new Student();
        var module1 = new StudentModule { Credit = 3, Grade = "A-" };
        var module2 = new StudentModule { Credit = 4, Grade = "B+" };
        var module3 = new StudentModule { Credit = 2, Grade = "C" };
        student.getModules = new ObservableCollection<StudentModule> { module1, module2, module3 };

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().BeApproximately(3.14, 0.01);
    }

    [Fact]
    public void CalcGPA_WithInvalidGrade_ShouldExcludeModuleFromCalculation()
    {
        // Arrange
        var student = new Student();
        var module1 = new StudentModule { Credit = 3, Grade = "A+" };
        var module2 = new StudentModule { Credit = 2, Grade = "XYZ" };
        var module3 = new StudentModule { Credit = 2, Grade = "B-" };
        student.getModules = new ObservableCollection<StudentModule> { module1, module2, module3 };

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().BeApproximately(3.56, 0.01);
    }

    [Fact]
    public void CalcGPA_WithModulesOfZeroCredit_ShouldExcludeModuleFromCalculation()
    {
        // Arrange
        var student = new Student();
        var module1 = new StudentModule { Credit = 3, Grade = "A-" };
        var module2 = new StudentModule { Credit = 0, Grade = "B+" };
        var module3 = new StudentModule { Credit = 2, Grade = "C" };
        student.getModules = new ObservableCollection<StudentModule> { module1, module2, module3 };

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().BeApproximately(3.02, 0.01);
    }

    [Fact]
    public void CalcGPA_WithAllModulesOfZeroCredit_ShouldReturnZero()
    {
        // Arrange
        var student = new Student();
        var module1 = new StudentModule { Credit = 0, Grade = "A" };
        var module2 = new StudentModule { Credit = 0, Grade = "B+" };
        student.getModules = new ObservableCollection<StudentModule> { module1, module2 };

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().Be(0.0);
    }

    [Fact]
    public void CalcGPA_WithLargeCreditValues_ShouldCalculateCorrectGpa()
    {
        // Arrange
        var student = new Student();
        var module1 = new StudentModule { Credit = 5, Grade = "A" };
        var module2 = new StudentModule { Credit = 7, Grade = "B+" };
        var module3 = new StudentModule { Credit = 4, Grade = "C-" };
        student.getModules = new ObservableCollection<StudentModule> { module1, module2, module3 };

        // Act
        var gpa = student.CalcGPA();

        // Assert
        gpa.Should().BeApproximately(3.12, 0.01);
    }
}
