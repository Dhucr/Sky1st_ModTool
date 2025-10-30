using Avalonia;
using Avalonia.Data;
using AvaloniaEdit;
using System;
using System.Collections.Generic;

namespace Sky1st_ModTool.Utils
{
    public class TextEditorHelper
    {
        /// <summary>
        /// 定义Text附加属性
        /// </summary>
        public static readonly AttachedProperty<string> TextProperty =
            AvaloniaProperty.RegisterAttached<TextEditorHelper, TextEditor, string>(
                "Text",
                default,
                false,
                BindingMode.TwoWay);

        /// <summary>
        /// 订阅状态附加属性
        /// </summary>
        private static readonly AttachedProperty<bool> IsSubscribedProperty =
            AvaloniaProperty.RegisterAttached<TextEditorHelper, TextEditor, bool>(
                "IsSubscribed",
                default);

        private static readonly Dictionary<TextEditor, bool> _updating = new();

        static TextEditorHelper()
        {
            TextProperty.Changed.AddClassHandler<TextEditor>(OnTextPropertyChanged);
            IsSubscribedProperty.Changed.AddClassHandler<TextEditor>(OnIsSubscribedChanged);
        }

        /// <summary>
        /// Text属性变更处理
        /// </summary>
        private static void OnTextPropertyChanged(TextEditor editor, AvaloniaPropertyChangedEventArgs args)
        {
            if (_updating.TryGetValue(editor, out var isUpdating) && isUpdating)
                return;

            try
            {
                _updating[editor] = true;
                var newValue = args.GetNewValue<string>();
                if (editor.Text != newValue)
                {
                    editor.Text = newValue;
                }
            }
            finally
            {
                _updating[editor] = false;
            }
        }

        /// <summary>
        /// TextEditor内容变更处理
        /// </summary>
        private static void OnTextChanged(object sender, EventArgs e)
        {
            if (sender is TextEditor editor)
            {
                if (_updating.TryGetValue(editor, out var isUpdating) && isUpdating)
                    return;

                try
                {
                    _updating[editor] = true;
                    SetText(editor, editor.Text ?? string.Empty);
                }
                finally
                {
                    _updating[editor] = false;
                }
            }
        }

        /// <summary>
        /// 订阅状态变更处理
        /// </summary>
        private static void OnIsSubscribedChanged(TextEditor editor, AvaloniaPropertyChangedEventArgs args)
        {
            var isSubscribed = args.GetNewValue<bool>();
            if (isSubscribed)
            {
                editor.TextChanged += OnTextChanged;
            }
            else
            {
                editor.TextChanged -= OnTextChanged;
            }
        }

        /// <summary>
        /// 设置Text附加属性
        /// </summary>
        public static void SetText(TextEditor element, string value)
        {
            element.SetValue(TextProperty, value);
            SetIsSubscribed(element, true); // 自动启用订阅
        }

        /// <summary>
        /// 获取Text附加属性
        /// </summary>
        public static string GetText(TextEditor element) =>
            element.GetValue(TextProperty);

        /// <summary>
        /// 获取订阅状态
        /// </summary>
        public static bool GetIsSubscribed(TextEditor element) =>
            element.GetValue(IsSubscribedProperty);

        /// <summary>
        /// 设置订阅状态
        /// </summary>
        public static void SetIsSubscribed(TextEditor element, bool value) =>
            element.SetValue(IsSubscribedProperty, value);
    }
}