﻿namespace desktop_test.Entity
{
    class Permission
    {
        public bool View { get; private set; }
        public bool Share { get; private set; }
        public bool Modify { get; private set; }
        public bool Add { get; private set; }

        public Permission(bool view, bool share, bool modify, bool add)
        {
            View = view;
            Share = share;
            Modify = modify;
            Add = add;
        }
    }
}
