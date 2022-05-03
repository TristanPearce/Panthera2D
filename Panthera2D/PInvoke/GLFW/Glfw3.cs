using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D.Native
{

    using static Panthera2D.Native.DLL;

    public static class Glfw3
    {
        static Glfw3()
        {
            Panthera2D.Native.Glfw3.csglLoadGlfw();
            Panthera2D.Native.Glfw3.glfwInit();
        }

        public static string GLFWWindows = "glfw3.dll";
        public static string GLFWLinux = "./libglfw.so";

        private static IntPtr _glfwHnd;

        #region Constants
        public const int GLFW_VERSION_MAJOR = 3;
        public const int GLFW_VERSION_MINOR = 2;
        public const int GLFW_VERSION_REVISION = 1;
        public const int GLFW_TRUE = 1;
        public const int GLFW_FALSE = 0;
        public const int GLFW_RELEASE = 0;
        public const int GLFW_PRESS = 1;
        public const int GLFW_REPEAT = 2;
        public const int GLFW_KEY_UNKNOWN = -1;
        public const int GLFW_KEY_SPACE = 32;
        public const int GLFW_KEY_APOSTROPHE = 39;
        public const int GLFW_KEY_COMMA = 44;
        public const int GLFW_KEY_MINUS = 45;
        public const int GLFW_KEY_PERIOD = 46;
        public const int GLFW_KEY_SLASH = 47;
        public const int GLFW_KEY_0 = 48;
        public const int GLFW_KEY_1 = 49;
        public const int GLFW_KEY_2 = 50;
        public const int GLFW_KEY_3 = 51;
        public const int GLFW_KEY_4 = 52;
        public const int GLFW_KEY_5 = 53;
        public const int GLFW_KEY_6 = 54;
        public const int GLFW_KEY_7 = 55;
        public const int GLFW_KEY_8 = 56;
        public const int GLFW_KEY_9 = 57;
        public const int GLFW_KEY_SEMICOLON = 59;
        public const int GLFW_KEY_EQUAL = 61;
        public const int GLFW_KEY_A = 65;
        public const int GLFW_KEY_B = 66;
        public const int GLFW_KEY_C = 67;
        public const int GLFW_KEY_D = 68;
        public const int GLFW_KEY_E = 69;
        public const int GLFW_KEY_F = 70;
        public const int GLFW_KEY_G = 71;
        public const int GLFW_KEY_H = 72;
        public const int GLFW_KEY_I = 73;
        public const int GLFW_KEY_J = 74;
        public const int GLFW_KEY_K = 75;
        public const int GLFW_KEY_L = 76;
        public const int GLFW_KEY_M = 77;
        public const int GLFW_KEY_N = 78;
        public const int GLFW_KEY_O = 79;
        public const int GLFW_KEY_P = 80;
        public const int GLFW_KEY_Q = 81;
        public const int GLFW_KEY_R = 82;
        public const int GLFW_KEY_S = 83;
        public const int GLFW_KEY_T = 84;
        public const int GLFW_KEY_U = 85;
        public const int GLFW_KEY_V = 86;
        public const int GLFW_KEY_W = 87;
        public const int GLFW_KEY_X = 88;
        public const int GLFW_KEY_Y = 89;
        public const int GLFW_KEY_Z = 90;
        public const int GLFW_KEY_LEFT_BRACKET = 91;
        public const int GLFW_KEY_BACKSLASH = 92;
        public const int GLFW_KEY_RIGHT_BRACKET = 93;
        public const int GLFW_KEY_GRAVE_ACCENT = 96;
        public const int GLFW_KEY_WORLD_1 = 161;
        public const int GLFW_KEY_WORLD_2 = 162;
        public const int GLFW_KEY_ESCAPE = 256;
        public const int GLFW_KEY_ENTER = 257;
        public const int GLFW_KEY_TAB = 258;
        public const int GLFW_KEY_BACKSPACE = 259;
        public const int GLFW_KEY_INSERT = 260;
        public const int GLFW_KEY_DELETE = 261;
        public const int GLFW_KEY_RIGHT = 262;
        public const int GLFW_KEY_LEFT = 263;
        public const int GLFW_KEY_DOWN = 264;
        public const int GLFW_KEY_UP = 265;
        public const int GLFW_KEY_PAGE_UP = 266;
        public const int GLFW_KEY_PAGE_DOWN = 267;
        public const int GLFW_KEY_HOME = 268;
        public const int GLFW_KEY_END = 269;
        public const int GLFW_KEY_CAPS_LOCK = 280;
        public const int GLFW_KEY_SCROLL_LOCK = 281;
        public const int GLFW_KEY_NUM_LOCK = 282;
        public const int GLFW_KEY_PRINT_SCREEN = 283;
        public const int GLFW_KEY_PAUSE = 284;
        public const int GLFW_KEY_F1 = 290;
        public const int GLFW_KEY_F2 = 291;
        public const int GLFW_KEY_F3 = 292;
        public const int GLFW_KEY_F4 = 293;
        public const int GLFW_KEY_F5 = 294;
        public const int GLFW_KEY_F6 = 295;
        public const int GLFW_KEY_F7 = 296;
        public const int GLFW_KEY_F8 = 297;
        public const int GLFW_KEY_F9 = 298;
        public const int GLFW_KEY_F10 = 299;
        public const int GLFW_KEY_F11 = 300;
        public const int GLFW_KEY_F12 = 301;
        public const int GLFW_KEY_F13 = 302;
        public const int GLFW_KEY_F14 = 303;
        public const int GLFW_KEY_F15 = 304;
        public const int GLFW_KEY_F16 = 305;
        public const int GLFW_KEY_F17 = 306;
        public const int GLFW_KEY_F18 = 307;
        public const int GLFW_KEY_F19 = 308;
        public const int GLFW_KEY_F20 = 309;
        public const int GLFW_KEY_F21 = 310;
        public const int GLFW_KEY_F22 = 311;
        public const int GLFW_KEY_F23 = 312;
        public const int GLFW_KEY_F24 = 313;
        public const int GLFW_KEY_F25 = 314;
        public const int GLFW_KEY_KP_0 = 320;
        public const int GLFW_KEY_KP_1 = 321;
        public const int GLFW_KEY_KP_2 = 322;
        public const int GLFW_KEY_KP_3 = 323;
        public const int GLFW_KEY_KP_4 = 324;
        public const int GLFW_KEY_KP_5 = 325;
        public const int GLFW_KEY_KP_6 = 326;
        public const int GLFW_KEY_KP_7 = 327;
        public const int GLFW_KEY_KP_8 = 328;
        public const int GLFW_KEY_KP_9 = 329;
        public const int GLFW_KEY_KP_DECIMAL = 330;
        public const int GLFW_KEY_KP_DIVIDE = 331;
        public const int GLFW_KEY_KP_MULTIPLY = 332;
        public const int GLFW_KEY_KP_SUBTRACT = 333;
        public const int GLFW_KEY_KP_ADD = 334;
        public const int GLFW_KEY_KP_ENTER = 335;
        public const int GLFW_KEY_KP_EQUAL = 336;
        public const int GLFW_KEY_LEFT_SHIFT = 340;
        public const int GLFW_KEY_LEFT_CONTROL = 341;
        public const int GLFW_KEY_LEFT_ALT = 342;
        public const int GLFW_KEY_LEFT_SUPER = 343;
        public const int GLFW_KEY_RIGHT_SHIFT = 344;
        public const int GLFW_KEY_RIGHT_CONTROL = 345;
        public const int GLFW_KEY_RIGHT_ALT = 346;
        public const int GLFW_KEY_RIGHT_SUPER = 347;
        public const int GLFW_KEY_MENU = 348;
        public const int GLFW_KEY_LAST = GLFW_KEY_MENU;
        public const int GLFW_MOD_SHIFT = 1;
        public const int GLFW_MOD_CONTROL = 2;
        public const int GLFW_MOD_ALT = 4;
        public const int GLFW_MOD_SUPER = 8;
        public const int GLFW_MOUSE_BUTTON_1 = 0;
        public const int GLFW_MOUSE_BUTTON_2 = 1;
        public const int GLFW_MOUSE_BUTTON_3 = 2;
        public const int GLFW_MOUSE_BUTTON_4 = 3;
        public const int GLFW_MOUSE_BUTTON_5 = 4;
        public const int GLFW_MOUSE_BUTTON_6 = 5;
        public const int GLFW_MOUSE_BUTTON_7 = 6;
        public const int GLFW_MOUSE_BUTTON_8 = 7;
        public const int GLFW_MOUSE_BUTTON_LAST = GLFW_MOUSE_BUTTON_8;
        public const int GLFW_MOUSE_BUTTON_LEFT = GLFW_MOUSE_BUTTON_1;
        public const int GLFW_MOUSE_BUTTON_RIGHT = GLFW_MOUSE_BUTTON_2;
        public const int GLFW_MOUSE_BUTTON_MIDDLE = GLFW_MOUSE_BUTTON_3;
        public const int GLFW_JOYSTICK_1 = 0;
        public const int GLFW_JOYSTICK_2 = 1;
        public const int GLFW_JOYSTICK_3 = 2;
        public const int GLFW_JOYSTICK_4 = 3;
        public const int GLFW_JOYSTICK_5 = 4;
        public const int GLFW_JOYSTICK_6 = 5;
        public const int GLFW_JOYSTICK_7 = 6;
        public const int GLFW_JOYSTICK_8 = 7;
        public const int GLFW_JOYSTICK_9 = 8;
        public const int GLFW_JOYSTICK_10 = 9;
        public const int GLFW_JOYSTICK_11 = 10;
        public const int GLFW_JOYSTICK_12 = 11;
        public const int GLFW_JOYSTICK_13 = 12;
        public const int GLFW_JOYSTICK_14 = 13;
        public const int GLFW_JOYSTICK_15 = 14;
        public const int GLFW_JOYSTICK_16 = 15;
        public const int GLFW_JOYSTICK_LAST = GLFW_JOYSTICK_16;
        public const int GLFW_NOT_INITIALIZED = 65537;
        public const int GLFW_NO_CURRENT_CONTEXT = 65538;
        public const int GLFW_INVALID_ENUM = 65539;
        public const int GLFW_INVALID_VALUE = 65540;
        public const int GLFW_OUT_OF_MEMORY = 65541;
        public const int GLFW_API_UNAVAILABLE = 65542;
        public const int GLFW_VERSION_UNAVAILABLE = 65543;
        public const int GLFW_PLATFORM_ERROR = 65544;
        public const int GLFW_FORMAT_UNAVAILABLE = 65545;
        public const int GLFW_NO_WINDOW_CONTEXT = 65546;
        public const int GLFW_FOCUSED = 131073;
        public const int GLFW_ICONIFIED = 131074;
        public const int GLFW_RESIZABLE = 131075;
        public const int GLFW_VISIBLE = 131076;
        public const int GLFW_DECORATED = 131077;
        public const int GLFW_AUTO_ICONIFY = 131078;
        public const int GLFW_FLOATING = 131079;
        public const int GLFW_MAXIMIZED = 131080;
        public const int GLFW_RED_BITS = 135169;
        public const int GLFW_GREEN_BITS = 135170;
        public const int GLFW_BLUE_BITS = 135171;
        public const int GLFW_ALPHA_BITS = 135172;
        public const int GLFW_DEPTH_BITS = 135173;
        public const int GLFW_STENCIL_BITS = 135174;
        public const int GLFW_ACCUM_RED_BITS = 135175;
        public const int GLFW_ACCUM_GREEN_BITS = 135176;
        public const int GLFW_ACCUM_BLUE_BITS = 135177;
        public const int GLFW_ACCUM_ALPHA_BITS = 135178;
        public const int GLFW_AUX_BUFFERS = 135179;
        public const int GLFW_STEREO = 135180;
        public const int GLFW_SAMPLES = 135181;
        public const int GLFW_SRGB_CAPABLE = 135182;
        public const int GLFW_REFRESH_RATE = 135183;
        public const int GLFW_DOUBLEBUFFER = 135184;
        public const int GLFW_CLIENT_API = 139265;
        public const int GLFW_CONTEXT_VERSION_MAJOR = 139266;
        public const int GLFW_CONTEXT_VERSION_MINOR = 139267;
        public const int GLFW_CONTEXT_REVISION = 139268;
        public const int GLFW_CONTEXT_ROBUSTNESS = 139269;
        public const int GLFW_OPENGL_FORWARD_COMPAT = 139270;
        public const int GLFW_OPENGL_DEBUG_CONTEXT = 139271;
        public const int GLFW_OPENGL_PROFILE = 139272;
        public const int GLFW_CONTEXT_RELEASE_BEHAVIOR = 139273;
        public const int GLFW_CONTEXT_NO_ERROR = 139274;
        public const int GLFW_CONTEXT_CREATION_API = 139275;
        public const int GLFW_NO_API = 0;
        public const int GLFW_OPENGL_API = 196609;
        public const int GLFW_OPENGL_ES_API = 196610;
        public const int GLFW_NO_ROBUSTNESS = 0;
        public const int GLFW_NO_RESET_NOTIFICATION = 200705;
        public const int GLFW_LOSE_CONTEXT_ON_RESET = 200706;
        public const int GLFW_OPENGL_ANY_PROFILE = 0;
        public const int GLFW_OPENGL_CORE_PROFILE = 204801;
        public const int GLFW_OPENGL_COMPAT_PROFILE = 204802;
        public const int GLFW_CURSOR = 208897;
        public const int GLFW_STICKY_KEYS = 208898;
        public const int GLFW_STICKY_MOUSE_BUTTONS = 208899;
        public const int GLFW_CURSOR_NORMAL = 212993;
        public const int GLFW_CURSOR_HIDDEN = 212994;
        public const int GLFW_CURSOR_DISABLED = 212995;
        public const int GLFW_ANY_RELEASE_BEHAVIOR = 0;
        public const int GLFW_RELEASE_BEHAVIOR_FLUSH = 217089;
        public const int GLFW_RELEASE_BEHAVIOR_NONE = 217090;
        public const int GLFW_NATIVE_CONTEXT_API = 221185;
        public const int GLFW_EGL_CONTEXT_API = 221186;
        public const int GLFW_ARROW_CURSOR = 221185;
        public const int GLFW_IBEAM_CURSOR = 221186;
        public const int GLFW_CROSSHAIR_CURSOR = 221187;
        public const int GLFW_HAND_CURSOR = 221188;
        public const int GLFW_HRESIZE_CURSOR = 221189;
        public const int GLFW_VRESIZE_CURSOR = 221190;
        public const int GLFW_CONNECTED = 262145;
        public const int GLFW_DISCONNECTED = 262146;
        public const int GLFW_DONT_CARE = -1;
        #endregion

        #region Delegates
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWvkproc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWerrorfun(int code, [In][MarshalAs(UnmanagedType.LPStr)] string description);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowposfun(IntPtr window, int x, int y);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowsizefun(IntPtr window, int w, int h);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowclosefun(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowrefreshfun(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowfocusfun(IntPtr window, int got);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWwindowiconifyfun(IntPtr window, int iconify);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWframebuffersizefun(IntPtr window, int w, int h);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWmousebuttonfun(IntPtr window, int button, int action, int mods);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWcursorposfun(IntPtr window, double x, double y);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWcursorenterfun(IntPtr window, int entered);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWscrollfun(IntPtr window, double xoffset, double yoffset);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWkeyfun(IntPtr window, int key, int scancode, int action, int mods);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWcharfun(IntPtr window, uint codepoint);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWcharmodsfun(IntPtr window, uint codepoint, int mods);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWdropfun(IntPtr window, int count, [Out] string[] paths);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWmonitorfun(IntPtr window, int ev);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GLFWjoystickfun(int window, int ev);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWINITPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWTERMINATEPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETVERSIONPROC(ref int major, ref int minor, ref int rev);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETVERSIONSTRINGPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWerrorfun PFNGLFWSETERRORCALLBACKPROC(GLFWerrorfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETMONITORSPROC(ref int count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETPRIMARYMONITORPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETMONITORPOSPROC(IntPtr monitor, ref int xpos, ref int ypos);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETMONITORPHYSICALSIZEPROC(IntPtr monitor, ref int widthMM, ref int heightMM);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETMONITORNAMEPROC(IntPtr monitor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWmonitorfun PFNGLFWSETMONITORCALLBACKPROC(GLFWmonitorfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETVIDEOMODESPROC(IntPtr monitor, ref int count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETVIDEOMODEPROC(IntPtr monitor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETGAMMAPROC(IntPtr monitor, float gamma);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETGAMMARAMPPROC(IntPtr monitor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETGAMMARAMPPROC(IntPtr monitor, ref GLFWgammaramp ramp);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWDEFAULTWINDOWHINTSPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWWINDOWHINTPROC(int hint, int value);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWCREATEWINDOWPROC(int width, int height, [In][MarshalAs(UnmanagedType.LPStr)] string title, IntPtr monitor, IntPtr share);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWDESTROYWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWWINDOWSHOULDCLOSEPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWSHOULDCLOSEPROC(IntPtr window, int value);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWTITLEPROC(IntPtr window, [In][MarshalAs(UnmanagedType.LPStr)] string title);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWICONPROC(IntPtr window, int count, ref GLFWimage images);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETWINDOWPOSPROC(IntPtr window, ref int xpos, ref int ypos);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWPOSPROC(IntPtr window, int xpos, int ypos);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETWINDOWSIZEPROC(IntPtr window, ref int width, ref int height);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWSIZELIMITSPROC(IntPtr window, int minwidth, int minheight, int maxwidth, int maxheight);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWASPECTRATIOPROC(IntPtr window, int numer, int denom);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWSIZEPROC(IntPtr window, int width, int height);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETFRAMEBUFFERSIZEPROC(IntPtr window, ref int width, ref int height);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETWINDOWFRAMESIZEPROC(IntPtr window, ref int left, ref int top, ref int right, ref int bottom);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWICONIFYWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWRESTOREWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWMAXIMIZEWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSHOWWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWHIDEWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWFOCUSWINDOWPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETWINDOWMONITORPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWMONITORPROC(IntPtr window, IntPtr monitor, int xpos, int ypos, int width, int height, int refreshRate);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWGETWINDOWATTRIBPROC(IntPtr window, int attrib);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETWINDOWUSERPOINTERPROC(IntPtr window, IntPtr pointer);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETWINDOWUSERPOINTERPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowposfun PFNGLFWSETWINDOWPOSCALLBACKPROC(IntPtr window, GLFWwindowposfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowsizefun PFNGLFWSETWINDOWSIZECALLBACKPROC(IntPtr window, GLFWwindowsizefun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowclosefun PFNGLFWSETWINDOWCLOSECALLBACKPROC(IntPtr window, GLFWwindowclosefun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowrefreshfun PFNGLFWSETWINDOWREFRESHCALLBACKPROC(IntPtr window, GLFWwindowrefreshfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowfocusfun PFNGLFWSETWINDOWFOCUSCALLBACKPROC(IntPtr window, GLFWwindowfocusfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWwindowiconifyfun PFNGLFWSETWINDOWICONIFYCALLBACKPROC(IntPtr window, GLFWwindowiconifyfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWframebuffersizefun PFNGLFWSETFRAMEBUFFERSIZECALLBACKPROC(IntPtr window, GLFWframebuffersizefun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWPOLLEVENTSPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWWAITEVENTSPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWWAITEVENTSTIMEOUTPROC(double timeout);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWPOSTEMPTYEVENTPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWGETINPUTMODEPROC(IntPtr window, int mode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETINPUTMODEPROC(IntPtr window, int mode, int value);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETKEYNAMEPROC(int key, int scancode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWGETKEYPROC(IntPtr window, int key);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWGETMOUSEBUTTONPROC(IntPtr window, int button);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWGETCURSORPOSPROC(IntPtr window, ref double xpos, ref double ypos);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETCURSORPOSPROC(IntPtr window, double xpos, double ypos);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWCREATECURSORPROC(ref GLFWimage image, int xhot, int yhot);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWCREATESTANDARDCURSORPROC(int shape);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWDESTROYCURSORPROC(IntPtr cursor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETCURSORPROC(IntPtr window, IntPtr cursor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWkeyfun PFNGLFWSETKEYCALLBACKPROC(IntPtr window, GLFWkeyfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWcharfun PFNGLFWSETCHARCALLBACKPROC(IntPtr window, GLFWcharfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWcharmodsfun PFNGLFWSETCHARMODSCALLBACKPROC(IntPtr window, GLFWcharmodsfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWmousebuttonfun PFNGLFWSETMOUSEBUTTONCALLBACKPROC(IntPtr window, GLFWmousebuttonfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWcursorposfun PFNGLFWSETCURSORPOSCALLBACKPROC(IntPtr window, GLFWcursorposfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWcursorenterfun PFNGLFWSETCURSORENTERCALLBACKPROC(IntPtr window, GLFWcursorenterfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWscrollfun PFNGLFWSETSCROLLCALLBACKPROC(IntPtr window, GLFWscrollfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWdropfun PFNGLFWSETDROPCALLBACKPROC(IntPtr window, GLFWdropfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWJOYSTICKPRESENTPROC(int joy);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETJOYSTICKAXESPROC(int joy, ref int count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETJOYSTICKBUTTONSPROC(int joy, ref int count);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETJOYSTICKNAMEPROC(int joy);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate GLFWjoystickfun PFNGLFWSETJOYSTICKCALLBACKPROC(GLFWjoystickfun cbfun);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETCLIPBOARDSTRINGPROC(IntPtr window, [In][MarshalAs(UnmanagedType.LPStr)] string @string);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETCLIPBOARDSTRINGPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double PFNGLFWGETTIMEPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSETTIMEPROC(double time);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint PFNGLFWGETTIMERVALUEPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint PFNGLFWGETTIMERFREQUENCYPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWMAKECONTEXTCURRENTPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETCURRENTCONTEXTPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSWAPBUFFERSPROC(IntPtr window);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PFNGLFWSWAPINTERVALPROC(int interval);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWEXTENSIONSUPPORTEDPROC([In][MarshalAs(UnmanagedType.LPStr)] string extension);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETPROCADDRESSPROC([In][MarshalAs(UnmanagedType.LPStr)] string procname);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PFNGLFWVULKANSUPPORTEDPROC();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr PFNGLFWGETREQUIREDINSTANCEEXTENSIONSPROC(ref uint count);
        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct GLFWvidmode
        {
            public int width;
            public int height;
            public int redBits;
            public int greenBits;
            public int blueBits;
            public int refreshRate;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GLFWgammaramp
        {
            public IntPtr red;
            public IntPtr green;
            public IntPtr blue;
            public uint size;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GLFWimage
        {
            public int width;
            public int height;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pixels;
        }
        #endregion

        #region Methods
        public static void csglLoadGlfw()
        {
            //if (__linux__)
                //_glfwHnd = Panthera2D.Native.DLL.Load(GLFWLinux);
            //else
                _glfwHnd = Panthera2D.Native.DLL.Load(GLFWWindows);

            Panthera2D.Native.DLL.LinkAllDelegates(typeof(Glfw3), _glfwHnd);
        }

        public static PFNGLFWINITPROC glfwInit;
        public static PFNGLFWTERMINATEPROC glfwTerminate;
        public static PFNGLFWGETVERSIONPROC glfwGetVersion;
        public static PFNGLFWGETVERSIONSTRINGPROC glfwGetVersionString;
        public static PFNGLFWSETERRORCALLBACKPROC glfwSetErrorCallback;
        public static PFNGLFWGETMONITORSPROC glfwGetMonitors;
        public static PFNGLFWGETPRIMARYMONITORPROC glfwGetPrimaryMonitor;
        public static PFNGLFWGETMONITORPOSPROC glfwGetMonitorPos;
        public static PFNGLFWGETMONITORPHYSICALSIZEPROC glfwGetMonitorPhysicalSize;
        public static PFNGLFWGETMONITORNAMEPROC glfwGetMonitorName;
        public static PFNGLFWSETMONITORCALLBACKPROC glfwSetMonitorCallback;
        public static PFNGLFWGETVIDEOMODESPROC glfwGetVideoModes;
        public static PFNGLFWGETVIDEOMODEPROC glfwGetVideoMode;
        public static PFNGLFWSETGAMMAPROC glfwSetGamma;
        public static PFNGLFWGETGAMMARAMPPROC glfwGetGammaRamp;
        public static PFNGLFWSETGAMMARAMPPROC glfwSetGammaRamp;
        public static PFNGLFWDEFAULTWINDOWHINTSPROC glfwDefaultWindowHints;
        public static PFNGLFWWINDOWHINTPROC glfwWindowHint;
        public static PFNGLFWCREATEWINDOWPROC glfwCreateWindow;
        public static PFNGLFWDESTROYWINDOWPROC glfwDestroyWindow;
        public static PFNGLFWWINDOWSHOULDCLOSEPROC glfwWindowShouldClose;
        public static PFNGLFWSETWINDOWSHOULDCLOSEPROC glfwSetWindowShouldClose;
        public static PFNGLFWSETWINDOWTITLEPROC glfwSetWindowTitle;
        public static PFNGLFWSETWINDOWICONPROC glfwSetWindowIcon;
        public static PFNGLFWGETWINDOWPOSPROC glfwGetWindowPos;
        public static PFNGLFWSETWINDOWPOSPROC glfwSetWindowPos;
        public static PFNGLFWGETWINDOWSIZEPROC glfwGetWindowSize;
        public static PFNGLFWSETWINDOWSIZELIMITSPROC glfwSetWindowSizeLimits;
        public static PFNGLFWSETWINDOWASPECTRATIOPROC glfwSetWindowAspectRatio;
        public static PFNGLFWSETWINDOWSIZEPROC glfwSetWindowSize;
        public static PFNGLFWGETFRAMEBUFFERSIZEPROC glfwGetFramebufferSize;
        public static PFNGLFWGETWINDOWFRAMESIZEPROC glfwGetWindowFrameSize;
        public static PFNGLFWICONIFYWINDOWPROC glfwIconifyWindow;
        public static PFNGLFWRESTOREWINDOWPROC glfwRestoreWindow;
        public static PFNGLFWMAXIMIZEWINDOWPROC glfwMaximizeWindow;
        public static PFNGLFWSHOWWINDOWPROC glfwShowWindow;
        public static PFNGLFWHIDEWINDOWPROC glfwHideWindow;
        public static PFNGLFWFOCUSWINDOWPROC glfwFocusWindow;
        public static PFNGLFWGETWINDOWMONITORPROC glfwGetWindowMonitor;
        public static PFNGLFWSETWINDOWMONITORPROC glfwSetWindowMonitor;
        public static PFNGLFWGETWINDOWATTRIBPROC glfwGetWindowAttrib;
        public static PFNGLFWSETWINDOWUSERPOINTERPROC glfwSetWindowUserPointer;
        public static PFNGLFWGETWINDOWUSERPOINTERPROC glfwGetWindowUserPointer;
        public static PFNGLFWSETWINDOWPOSCALLBACKPROC glfwSetWindowPosCallback;
        public static PFNGLFWSETWINDOWSIZECALLBACKPROC glfwSetWindowSizeCallback;
        public static PFNGLFWSETWINDOWCLOSECALLBACKPROC glfwSetWindowCloseCallback;
        public static PFNGLFWSETWINDOWREFRESHCALLBACKPROC glfwSetWindowRefreshCallback;
        public static PFNGLFWSETWINDOWFOCUSCALLBACKPROC glfwSetWindowFocusCallback;
        public static PFNGLFWSETWINDOWICONIFYCALLBACKPROC glfwSetWindowIconifyCallback;
        public static PFNGLFWSETFRAMEBUFFERSIZECALLBACKPROC glfwSetFramebufferSizeCallback;
        public static PFNGLFWPOLLEVENTSPROC glfwPollEvents;
        public static PFNGLFWWAITEVENTSPROC glfwWaitEvents;
        public static PFNGLFWWAITEVENTSTIMEOUTPROC glfwWaitEventsTimeout;
        public static PFNGLFWPOSTEMPTYEVENTPROC glfwPostEmptyEvent;
        public static PFNGLFWGETINPUTMODEPROC glfwGetInputMode;
        public static PFNGLFWSETINPUTMODEPROC glfwSetInputMode;
        public static PFNGLFWGETKEYNAMEPROC glfwGetKeyName;
        public static PFNGLFWGETKEYPROC glfwGetKey;
        public static PFNGLFWGETMOUSEBUTTONPROC glfwGetMouseButton;
        public static PFNGLFWGETCURSORPOSPROC glfwGetCursorPos;
        public static PFNGLFWSETCURSORPOSPROC glfwSetCursorPos;
        public static PFNGLFWCREATECURSORPROC glfwCreateCursor;
        public static PFNGLFWCREATESTANDARDCURSORPROC glfwCreateStandardCursor;
        public static PFNGLFWDESTROYCURSORPROC glfwDestroyCursor;
        public static PFNGLFWSETCURSORPROC glfwSetCursor;
        public static PFNGLFWSETKEYCALLBACKPROC glfwSetKeyCallback;
        public static PFNGLFWSETCHARCALLBACKPROC glfwSetCharCallback;
        public static PFNGLFWSETCHARMODSCALLBACKPROC glfwSetCharModsCallback;
        public static PFNGLFWSETMOUSEBUTTONCALLBACKPROC glfwSetMouseButtonCallback;
        public static PFNGLFWSETCURSORPOSCALLBACKPROC glfwSetCursorPosCallback;
        public static PFNGLFWSETCURSORENTERCALLBACKPROC glfwSetCursorEnterCallback;
        public static PFNGLFWSETSCROLLCALLBACKPROC glfwSetScrollCallback;
        public static PFNGLFWSETDROPCALLBACKPROC glfwSetDropCallback;
        public static PFNGLFWJOYSTICKPRESENTPROC glfwJoystickPresent;
        public static PFNGLFWGETJOYSTICKAXESPROC glfwGetJoystickAxes;
        public static PFNGLFWGETJOYSTICKBUTTONSPROC glfwGetJoystickButtons;
        public static PFNGLFWGETJOYSTICKNAMEPROC glfwGetJoystickName;
        public static PFNGLFWSETJOYSTICKCALLBACKPROC glfwSetJoystickCallback;
        public static PFNGLFWSETCLIPBOARDSTRINGPROC glfwSetClipboardString;
        public static PFNGLFWGETCLIPBOARDSTRINGPROC glfwGetClipboardString;
        public static PFNGLFWGETTIMEPROC glfwGetTime;
        public static PFNGLFWSETTIMEPROC glfwSetTime;
        public static PFNGLFWGETTIMERVALUEPROC glfwGetTimerValue;
        public static PFNGLFWGETTIMERFREQUENCYPROC glfwGetTimerFrequency;
        public static PFNGLFWMAKECONTEXTCURRENTPROC glfwMakeContextCurrent;
        public static PFNGLFWGETCURRENTCONTEXTPROC glfwGetCurrentContext;
        public static PFNGLFWSWAPBUFFERSPROC glfwSwapBuffers;
        public static PFNGLFWSWAPINTERVALPROC glfwSwapInterval;
        public static PFNGLFWEXTENSIONSUPPORTEDPROC glfwExtensionSupported;
        public static PFNGLFWGETPROCADDRESSPROC glfwGetProcAddress;
        public static PFNGLFWVULKANSUPPORTEDPROC glfwVulkanSupported;
        public static PFNGLFWGETREQUIREDINSTANCEEXTENSIONSPROC glfwGetRequiredInstanceExtensions;
        #endregion
    }
}
