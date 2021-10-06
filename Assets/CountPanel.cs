using Framework;
using UnityEngine;
using UnityEngine.UI;

public class CountPanel : BaseViewController
{
    public Text mText;
    public Button mAddButton;
    public Button mSubButton;

    private void Awake()
    {
        var countModel = this.GetModel<CountModel>();
        mText.text = countModel.Count.Value.ToString();
        countModel.Count.OnValueChanged += OnCountChange;

        mAddButton.onClick.AddListener(() => this.SendCommand<AddCountCommand>());
        mSubButton.onClick.AddListener(() => this.SendCommand<SubCountCommand>());

        this.RegisterEvent<AchievementEvent>(OnAchievementEvent);
    }

    private void OnAchievementEvent(AchievementEvent e)
    {
        Debug.Log(string.Format("成就达成{0}", e.value));
    }

    private void OnDestroy()
    {
        var countModel = this.GetModel<CountModel>();
        countModel.Count.OnValueChanged -= OnCountChange;
    }

    private void OnCountChange(in int value)
    {
        mText.text = value.ToString();
    }
}
