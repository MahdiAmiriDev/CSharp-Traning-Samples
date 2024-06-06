namespace inheritance.HidenMehtod
{
    public class Parent
    {
        public string SayMyName() => "Mehdi";
    }

    /// <summary>
    /// این متد برای کلاس پدر خود عضوی را مخی کرده با استفاده از کلمه کلیدی نیو
    /// </summary>
    public class Child: Parent
    {
        public new string SayMyName() => "Amiri";
    }
}
