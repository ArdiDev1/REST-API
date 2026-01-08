namespace BackendApi.Dtos
{
    public record ComputerDto
    {
        public int Id { get; set; }
        public string? Ram { get; set; }
        public string? CPU { get; set; }
        public int CPUCores { get; set; }
        public string? VideoCard { get; set; }
        public int RefreshRate { get; set; }
    }
}
