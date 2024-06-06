using EventSample;

var Teacher = new Teacher("mahdi", "amiri");

TeacherChangeNameLogger tl = new();

Teacher.TeacherNameChange += tl.Log;

Teacher.SetName("mmd reza");