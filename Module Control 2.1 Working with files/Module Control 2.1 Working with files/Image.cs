namespace Module_Control_2._1_Working_with_files
{
    class Image: BaseFile
    {
        public string Resolution { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + $"MB\n\t\tResolution: {Resolution}";
        }
    }
}
