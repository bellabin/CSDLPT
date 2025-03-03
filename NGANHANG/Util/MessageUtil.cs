﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG.Util
{
    class MessageUtil
    {
        public static void ShowInfoMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarnMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowErrorMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowInfoConfirmDialog(string msg)
        {
            return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public static DialogResult ShowWarnConfirmDialog(string msg)
        {
            return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
