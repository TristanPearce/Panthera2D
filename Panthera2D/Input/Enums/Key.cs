using System;
using System.Collections.Generic;
using System.Text;

namespace Panthera2D.Input
{
    /// <summary>
    /// Enumeration for virtual keys.
    /// </summary>
    public enum Key
        : ushort
    {
        None,
        NotAKey,
        Invalid,
        Unknown,

        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,

        //Topline numbers

        N0,
        N1,
        N2,
        N3,
        N4,
        N5,
        N6,
        N7,
        N8,
        N9,

        Underscore,
        Minus,
        Plus,
        Equals,

        //Keypad

        Numpad0,
        Numpad1,
        Numpad2,
        Numpad3,
        Numpad4,
        Numpad5,
        Numpad6,
        Numpad7,
        Numpad8,
        Numpad9,
        NumpadPlus,
        NumpadMinus,
        NumpadMultiply,
        NumpadDivide,
        NumpadEnter,
        NumpadDecimal,

        //Funtions

        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        F13,
        F14,
        F15,
        F16,
        F17,
        F18,
        F19,
        F20,
        F21,
        F22,
        F23,
        F24,

        //Arrows

        Up,
        Down,
        Left,
        Right,

        //Misc

        OpenSquareBracket,
        CloseSquareBracket,
        ForwardSlash,
        SemiColon,
        Period,
        Comma,
        BackSlash,
        SingleQuote,
        DoubleQuote,
        /// <summary>
        /// Same as hashtag
        /// </summary>
        Pound,
        Space,
        Escape,
        Tab,
        CapsLock,
        Tilde,
        LeftControl,
        LeftShift,
        LeftAlt,
        LeftWindows,
        RightControl,
        RightShift,
        RightAlt,
        PrintScreen,
        Insert,
        Delete,
        PageUp,
        PageDown,
        Home,
        End,
        Backspace,
        /// <summary>
        /// Same as enter
        /// </summary>
        Return,
    }
}
