namespace SejmCalendar.Blazor;

public static class BirthdayHelpers
{
    public static int AgeToday(this DateTime birthDate)
    {
        int birthYear = birthDate.Year;
        int currentYear = DateTime.Now.Year;

        return (currentYear - birthYear);
    }

    public static string AgeText(this int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age must be a positive number.");
        }
        else if (age == 1)
        {
            return $"{age} rok";
        }
        else if (age % 10 == 2 || age % 10 == 3 || age % 10 == 4)
        {
            return $"{age} lata";
        }
        else
        {
            return $"{age} lat";
        }
    }
}
