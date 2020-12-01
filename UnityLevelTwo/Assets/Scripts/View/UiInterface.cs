using UnityEngine;


public sealed class UiInterface
{
    #region Fields

    private FlashLightUiText _flashLightUiText;
    private FlashLightUiBar _flashLightUiBar;
    private WeaponUiText _weaponUiText;
    private SelectionObjMessageUi _selectionObjMessageUi;
    private SelectionObjMessageUiImage _selectionObjMessageUiImage;
    private PlayerUiBar _playerUiBar;
    private PlayerUiText _playerUiText;
    private ChangeHealthUi _changeHealthUi;
    private WeaponUiImage _weaponUiImage;
    private PauseUi _pauseUi;
    private AimUiImage _aimUiImage;

    #endregion


    #region ClassLifeCycless

    public FlashLightUiText LightUiText
    {
        get
        {
            if (!_flashLightUiText)
            {
                _flashLightUiText = Object.FindObjectOfType<FlashLightUiText>();
            }
            return _flashLightUiText;
        }
    }

    public FlashLightUiBar LightUiBar
    {
        get
        {
            if (!_flashLightUiBar)
            {
                _flashLightUiBar = Object.FindObjectOfType<FlashLightUiBar>();
            }
            return _flashLightUiBar;
        }
    }

    public WeaponUiText WeaponUiText
    {
        get
        {
            if (!_weaponUiText)
            {
                _weaponUiText = Object.FindObjectOfType<WeaponUiText>();
            }
            return _weaponUiText;
        }
    }

    public SelectionObjMessageUi SelectionObjMessageUi
    {
        get
        {
            if (!_selectionObjMessageUi)
            {
                _selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
            }
            return _selectionObjMessageUi;
        }
    }

    public SelectionObjMessageUiImage SelectionObjMessageUiImage
    {
        get
        {
            if (!_selectionObjMessageUiImage)
            {
                _selectionObjMessageUiImage = Object.FindObjectOfType<SelectionObjMessageUiImage>();
            }
            return _selectionObjMessageUiImage;
        }
    }

    public PlayerUiBar PlayerUiBar
    {
        get
        {
            if (!_playerUiBar)
            {
                _playerUiBar = Object.FindObjectOfType<PlayerUiBar>();
            }

            return _playerUiBar;
        }
    }

    public PlayerUiText PlayerUiText
    {
        get
        {
            if (!_playerUiText)
            {
                _playerUiText = Object.FindObjectOfType<PlayerUiText>();
            }

            return _playerUiText;
        }
    }

    public ChangeHealthUi ChangeHealthUi
    {
        get
        {
            if (!_changeHealthUi)
            {
                _changeHealthUi = Object.FindObjectOfType<ChangeHealthUi>();
            }

            return _changeHealthUi;
        }
    }

    public WeaponUiImage WeaponUiImage
    {
        get
        {
            if (!_weaponUiImage)
            {
                _weaponUiImage = Object.FindObjectOfType<WeaponUiImage>();
            }

            return _weaponUiImage;
        }
    }

    public PauseUi PauseUi
    {
        get
        {
            if (!_pauseUi)
            {
                _pauseUi = Object.FindObjectOfType<PauseUi>();
            }

            return _pauseUi;
        }
    }

    public AimUiImage AimUiImage
    {
        get
        {
            if (!_aimUiImage)
            {
                _aimUiImage = Object.FindObjectOfType<AimUiImage>();
            }

            return _aimUiImage;
        }
    }

    #endregion
}