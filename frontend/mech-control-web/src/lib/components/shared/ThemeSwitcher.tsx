import React from "react";
import { IconButton } from "@mui/material";
import {
  Brightness4 as Brightness4Icon,
  Brightness7 as Brightness7Icon,
} from "@mui/icons-material";
import { useCustomTheme } from "@/lib/contexts/custom-theme-context";

const ThemeSwitcher = () => {
  const { theme, toggleTheme } = useCustomTheme();

  return (
    <IconButton onClick={toggleTheme} color="inherit">
      {theme.palette.mode === "dark" ? (
        <Brightness7Icon />
      ) : (
        <Brightness4Icon />
      )}
    </IconButton>
  );
};

export default ThemeSwitcher;
