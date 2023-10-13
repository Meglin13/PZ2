namespace SaveLoadSystem
{
    public interface ISaveable
    {
        object GetObjects();
        void LoadObjects(object save);
    }
}