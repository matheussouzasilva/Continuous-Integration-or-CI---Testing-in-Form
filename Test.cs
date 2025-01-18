using System;

namespace Test
{
    public static class ValidatorTests
    {
        public static void RunTests()
        {
            Console.WriteLine("\nRunning Tests...");
            TestValidateName();
            TestValidateAge();
            Console.WriteLine("All tests passed!");
        }

        private static void TestValidateName()
        {
            if (!ValidateName("John")) throw new Exception("Test failed: 'John' should be valid.");
            if (ValidateName("")) throw new Exception("Test failed: '' should be invalid.");
            if (ValidateName(null)) throw new Exception("Test failed: null should be invalid.");
            if (ValidateName("   ")) throw new Exception("Test failed: '   ' should be invalid.");
            Console.WriteLine("TestValidateName passed.");
        }

        private static void TestValidateAge()
        {
            if (!ValidateAge("25", out int age1) || age1 != 25) throw new Exception("Test failed: '25' should be valid.");
            if (ValidateAge("-1", out _)) throw new Exception("Test failed: '-1' should be invalid.");
            if (ValidateAge("abc", out _)) throw new Exception("Test failed: 'abc' should be invalid.");
            if (ValidateAge("", out _)) throw new Exception("Test failed: '' should be invalid.");
            Console.WriteLine("TestValidateAge passed.");
        }

        private static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        private static bool ValidateAge(string ageInput, out int age)
        {
            bool isValid = int.TryParse(ageInput, out age) && age > 0;
            return isValid;
        }
    }
}
