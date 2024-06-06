namespace inheritance.Abstract
{
    /// <summary>
    /// در این مثال یک متد ابسترکت داریم که همه از کلاس ان ارث برده اند پس بنابر این باید عضو آن را
    /// اوریراید کنند حالا لیستی از آن کلاس ایجاد کرده فرزند ها را ادد می کنیم 
    /// و در نهایت بر روی متد مشترک بین آن ها لوپ زده و همه را کال می کنیم
    /// </summary>
    public abstract class AbstarctParent
    {
        public abstract void AnimalFood();
    }

    public class Dog : AbstarctParent
    {
        public override void AnimalFood()
        {
            Console.WriteLine("meet");
        }
    }

    public class Cat : AbstarctParent
    {
        public override void AnimalFood()
        {
            Console.WriteLine("milk");
        }
    }

    public class RunClass
    {
        public void RunThem()
        {
            List<AbstarctParent> abstarctParents = new List<AbstarctParent>();

            AbstarctParent parentClass;

            Cat cOne = new Cat();
            AbstarctParent cTwo = new Dog();

            abstarctParents.Add(cOne);
            abstarctParents.Add(cTwo);

            foreach(var item in abstarctParents)
            {
                item.AnimalFood();
            }

        }
    }
}
