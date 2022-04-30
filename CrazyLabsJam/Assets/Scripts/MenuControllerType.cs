

public class MenuControllerType : MenuControllerAbstract
{

    override public void Show(CustomizationSet[] customizationSets=null){
        if(customizationSets==null)   return;
        else                          this.componentContainerController.ShowTools(customizationSets);

        this.gameObject.SetActive(true);

    }

}
