namespace Module_Control_2._1_Working_with_files
{
    class Movie: BaseFile
    {
        public string Resolution { get; set; }

        public string Length { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + $"GB\n\t\tResolution: {Resolution}\n\t\tLength: {Length}";
        }
    }
}
