"use client";

import {
  AppBar,
  Toolbar,
  Drawer,
  IconButton,
  Stack,
  Typography,
} from "@mui/material";
import SidebarItems from "./SidebarItems";
import { useState } from "react";
import { Menu, ChevronLeft } from "@mui/icons-material";

type SidebarProps = {
  closeSidebar: () => void;
  isSidebarOpen: boolean;
};

const Sidebar = ({
  isSidebarOpen,
  closeSidebar
}: SidebarProps) => {
  const sidebarWidth = 270;
  return (
    <>
      {isSidebarOpen && (
        <Drawer
          sx={{
            width: sidebarWidth,
            flexShrink: 0,
            "& .MuiDrawer-paper": {
              width: sidebarWidth,
              boxSizing: "border-box",
            },
          }}
          open={isSidebarOpen}
          anchor="left"
          variant="persistent"
        >
          <Stack direction="row" justifyContent="flex-end">
            <IconButton onClick={closeSidebar}>
              <ChevronLeft />
            </IconButton>
          </Stack>
          <SidebarItems />
        </Drawer>
      )}
    </>
  );
};

export default Sidebar;
