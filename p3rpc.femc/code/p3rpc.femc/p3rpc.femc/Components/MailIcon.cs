using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;

namespace p3rpc.femc.Components
{
    public class MailIcon : ModuleBase<FemcContext>
    {
        private string AUIMailIconDraw_DrawMailIconInner_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 48 8D 68 ?? 48 81 EC 10 01 00 00 0F 29 70 ?? 0F 29 78 ??";
        private IHook<AUIMailIconDraw_DrawMailIconInner> _drawMailIcon;
        private UICommon _uiCommon;

        public unsafe MailIcon(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMailIconDraw_DrawMailIconInner_SIG, "AUIMailIconDraw::DrawMailIconInner", _context._utils.GetDirectAddress, addr => _drawMailIcon = _context._utils.MakeHooker<AUIMailIconDraw_DrawMailIconInner>(AUIMailIconDraw_DrawMailIconInnerImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void AUIMailIconDraw_DrawMailIconInnerImpl(AUIMailIconDraw* self)
        {
            // final param refers to entries in SPR_UI_MAIL.uasset (tex T_UI_Mail_00_texture.uasset)
            var itemMask = _uiCommon._getSpriteItemMaskInstance() + 0x20;
            _uiCommon._setPresetBlendState(itemMask, 0);
            var circlePos = new FVector2D(80, 74);
            // Static Outer Circle
            var staticOuterCircle = new SprDefStruct1(
                0,
                circlePos,
                ConfigColor.ToFSprColor(_context._config.MailIconOuterCircleColorEx),
                self->Field368, 0, 0);
            _uiCommon._spriteFunc1(&staticOuterCircle, itemMask, self->Sprite_, 0, 0);
            // Pulsing Inner Circle
            var pulsateColor = ConfigColor.ToFSprColor(_context._config.MailIconInnerCircleColorEx);
            pulsateColor.A = (byte)(self->Field408 * 255);
            var pulsateInnerCircle = new SprDefStruct1(
                0,
                circlePos,
                pulsateColor,
                (float)(self->Field318 * 0.6 + self->Field3B8), 0, 0);
            _uiCommon._spriteFunc1(&pulsateInnerCircle, itemMask, self->Sprite_, 0, 0);
            // Static Inner Circle
            var staticInnerCircle = new SprDefStruct1(
                0,
                circlePos,
                ConfigColor.ToFSprColor(_context._config.MailIconInnerCircleColorEx),
                (float)(self->Field318 * 0.695), 0, 0);
            _uiCommon._spriteFunc1(&staticInnerCircle, itemMask, self->Sprite_, 0, 0);
            // Mail Icon
            var mailIcon = new SprDefStruct1(
                1,
                new FVector2D(80, 68),
                ConfigColor.ToFSprColor(_context.ColorWhite),
                1, 0, 0
            );
            _uiCommon._spriteFunc1(&mailIcon, itemMask, self->Sprite_, 0, 0);
            // Mail Notification Indicator
            var mailHasNotificationsColor = ConfigColor.ToFSprColor(_context.ColorWhite);
            mailHasNotificationsColor.A = (byte)(self->Field318 * 255);
            var mailHasNotifications = new SprDefStruct1(
                2,
                new FVector2D(120, 94),
                mailHasNotificationsColor,
                1, self->Field2D0, 0
            );
            _uiCommon._spriteFunc1(&mailHasNotifications, itemMask, self->Sprite_, 0, 0);
        }

        private unsafe delegate void AUIMailIconDraw_DrawMailIconInner(AUIMailIconDraw* self);
    }
}
