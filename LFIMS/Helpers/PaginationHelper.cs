using System;
using System.Drawing;
using System.Windows.Forms;

namespace LFsystem.Helpers
{
    public class PaginationHelper
    {
        public FlowLayoutPanel FlowPanel { get; set; }

        public void GenerateButtons(int currentPage, int totalPages, Action<int> onPageClick)
        {
            FlowPanel.Controls.Clear();
            FlowPanel.WrapContents = false;
            FlowPanel.AutoSize = true;
            FlowPanel.Padding = new Padding(0);
            FlowPanel.Margin = new Padding(0);

            int start = Math.Max(1, currentPage - 2);
            int end = Math.Min(totalPages, start + 4);
            if (end - start < 4) start = Math.Max(1, end - 4);

            // << First
            FlowPanel.Controls.Add(CreatePageButton("<<", () => onPageClick(1), currentPage > 1));

            // < Prev
            FlowPanel.Controls.Add(CreatePageButton("<", () => onPageClick(Math.Max(1, currentPage - 1)), currentPage > 1));

            // Page numbers
            for (int i = start; i <= end; i++)
            {
                int pageNumber = i;
                bool isActive = i == currentPage;
                var btn = CreatePageButton(i.ToString(), () => onPageClick(pageNumber), true);

                if (isActive)
                {
                    btn.BackColor = Color.DodgerBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                }

                FlowPanel.Controls.Add(btn);
            }

            // > Next
            FlowPanel.Controls.Add(CreatePageButton(">", () => onPageClick(Math.Min(totalPages, currentPage + 1)), currentPage < totalPages));

            // >> Last
            FlowPanel.Controls.Add(CreatePageButton(">>", () => onPageClick(totalPages), currentPage < totalPages));
        }

        private Button CreatePageButton(string text, Action onClick, bool enabled)
        {
            Button btn = new Button
            {
                Text = text,
                Height = 32,
                Margin = new Padding(2),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand,
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                FlatAppearance = { BorderColor = Color.LightGray, BorderSize = 1 },
                Enabled = enabled
            };

            // Fix width for navigation buttons (<<, <, >, >>)
            if (text.Length > 1) // << or >>
                btn.Width = 40;
            else // single digit numbers or < >
                btn.Width = 32;

            btn.Click += (s, e) => onClick();
            btn.MouseEnter += (s, e) =>
            {
                if (!btn.BackColor.Equals(Color.DodgerBlue))
                    btn.BackColor = Color.Gainsboro;
            };
            btn.MouseLeave += (s, e) =>
            {
                if (!btn.BackColor.Equals(Color.DodgerBlue))
                    btn.BackColor = Color.WhiteSmoke;
            };

            return btn;
        }

    }
}
