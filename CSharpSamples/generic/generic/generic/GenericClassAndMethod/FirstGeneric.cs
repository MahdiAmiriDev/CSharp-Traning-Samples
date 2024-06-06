namespace generic.GenericClassAndMethod
{
    /// <summary>
    /// کلاس و متد جنریک
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public class FirstGeneric<TInput>
    {

        public void concat(TInput left, TInput right)
        {
            //مقدار پیش فرض نوع داده
            var leftDefault = default(TInput);

            var first = left.ToString();
            var second = right.ToString();

            Console.WriteLine($"left is {first} and right is {right}");
        }

        /// <summary>
        /// مقدار پیش فرض را برای برای دیتا تایپ بازگشتی بر میگرداند
        /// </summary>
        /// <returns></returns>
        public int TestForReturnDefault()
        {
            Dictionary<string, object> dictionary = new();

            return default;
        }

    }
    /// <summary>
    /// اورراید کردن تو استرینپ برای یک تایپ خاص
    /// </summary>
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString()
        {
            return $"my name is {FirstName} and my last Name is {LastName}";
        }
    }

    //--------------------------------------------

    public class Teacher : Person
    {
        public int Id { get; set; }
    }

    public class Car : Person
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// جنریک به همراه تبدیل نوع و همچنین قرار دادن شرطی مبنی بر کلاس بودن
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public class PrintPerson<TInput> where TInput : class
    {
        public void Print(TInput input)
        {
            var person = input as Person;

            if (person is Person)
            {
                Console.WriteLine("is person !!!");
            }

            Console.WriteLine($"name is {person.FirstName} , lsatNameIs {person.LastName}");
        }
    }

    //--------------------------------------------inheritance

    public class ParentIn<Tinput, TInput2>
    {

    }

    public class childOne:ParentIn<int , string>
    {

    }

    public class childOne<TInput> : ParentIn<TInput, string>
    {

    }

    //-----------------------------------------------------

    public class WithStaticMember<Tinput>
    {
        public static int Counter;
    }


}
