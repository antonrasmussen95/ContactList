namespace ContactList2.Interfaces;

// Interface för menyn som bestämmer vad som ska vara med // 
internal interface IMenuService
{
    public void MainMenu();
    public void AddMenu();
    public void GetAllMenu();
    public void GetSpecificMenu();
    public void DeleteMenu(); 

}
