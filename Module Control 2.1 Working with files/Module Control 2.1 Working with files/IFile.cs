namespace Module_Control_2._1_Working_with_files
{
    interface IFile
    {   
        string Name { get; set; }
        string Extension { get; set; }
        int Size { get; set; }
    }
}
