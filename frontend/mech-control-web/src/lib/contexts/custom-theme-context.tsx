"use client";

import React, { createContext, useContext, useState } from "react";
import { ThemeProvider, CssBaseline } from "@mui/material";
import { lightTheme, darkTheme } from "@/lib/style/theme";

interface CustomThemeContextType {
  theme: typeof lightTheme;
  toggleTheme: () => void;
}

const CustomThemeContext = createContext<CustomThemeContextType | undefined>(
  undefined
);

export const useCustomTheme = () => {
  const context = useContext(CustomThemeContext);
  if (!context) {
    throw new Error("useCustomTheme must be used within a CustomThemeProvider");
  }
  return context;
};

export const CustomThemeProvider = ({
  children,
}: {
  children: React.ReactNode;
}) => {
  const [theme, setTheme] = useState(lightTheme);

  const toggleTheme = () => {
    setTheme((prevTheme) =>
      prevTheme.palette.mode === "light" ? darkTheme : lightTheme
    );
  };

  return (
    <CustomThemeContext.Provider value={{ theme, toggleTheme }}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        {children}
      </ThemeProvider>
    </CustomThemeContext.Provider>
  );
};
