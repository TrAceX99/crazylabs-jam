

public class MenuController : MenuControllerAbstract
{

    override public void Show(CustomizationSet customizationSet){
        if(customizationSet==null)   this.Show();
        else            this.componentContainerController.ShowToolsSet(customizationSet);

        this.gameObject.SetActive(true);

    }


    override public void Show(){
        this.componentContainerController.ShowToolsBasic();

        this.gameObject.SetActive(true);

    }

}
