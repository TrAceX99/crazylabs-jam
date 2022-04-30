

public class MenuController : MenuControllerAbstract
{

    override public void Show(CustomizationSet customizationSet){
        if(customizationSet==null)   this.Show();
        else            this.componentContainerController.ShowToolsSet(customizationSet);

        this.gameObject.SetActive(true);

        scrollRect.horizontalNormalizedPosition = 0f;
    }


    override public void Show(){
        this.componentContainerController.ShowToolsBasic();

        this.gameObject.SetActive(true);

        scrollRect.horizontalNormalizedPosition = 0f;
    }

}
