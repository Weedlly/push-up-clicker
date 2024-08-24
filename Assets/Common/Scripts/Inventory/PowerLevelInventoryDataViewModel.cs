namespace Common.Scripts.Inventory
{
    public sealed class PowerLevelInventoryDataViewModel : CommonInventoryDataViewModel
    {
        protected override void SetUpView()
        {
            _inventoryDataView.Setup(_inventoryDataAsset.GetPowerLevel());
        }
    }
}
