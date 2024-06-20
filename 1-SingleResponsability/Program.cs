using SingleResponsability;

StudentRepository studentRepository = new();
ExportHelperCSV<Student> exportStudent = new();
exportStudent.Export(studentRepository.GetAll());
Console.WriteLine("Proceso Completado");