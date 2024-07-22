import { createTheme } from '@mui/material/styles';

// Define color shades
const colors = {
  primary: {
    50: '#e3f2fd',
    100: '#bbdefb',
    200: '#90caf9',
    300: '#64b5f6',
    400: '#42a5f5',
    500: '#2196f3',
    600: '#1e88e5',
    700: '#1976d2',
    800: '#1565c0',
    900: '#0d47a1',
  },
  secondary: {
    50: '#fce4ec',
    100: '#f8bbd0',
    200: '#f48fb1',
    300: '#f06292',
    400: '#ec407a',
    500: '#e91e63',
    600: '#d81b60',
    700: '#c2185b',
    800: '#ad1457',
    900: '#880e4f',
  },
};

const lightTheme = createTheme({
  palette: {
    mode: 'light',
    primary: {
      main: colors.primary[500],
      light: colors.primary[300],
      dark: colors.primary[700],
      contrastText: '#fff',
    },
    secondary: {
      main: colors.secondary[500],
      light: colors.secondary[300],
      dark: colors.secondary[700],
      contrastText: '#fff',
    },
    background: {
      default: '#f5f5f5',
      paper: '#fff',
    },
  },
  typography: {
    fontFamily: 'Roboto, Arial',
  },
});

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: colors.primary[200],
      light: colors.primary[100],
      dark: colors.primary[300],
      contrastText: '#000',
    },
    secondary: {
      main: colors.secondary[200],
      light: colors.secondary[100],
      dark: colors.secondary[300],
      contrastText: '#000',
    },
    background: {
      default: '#303030',
      paper: '#424242',
    },
  },
  typography: {
    fontFamily: 'Roboto, Arial',
  },
});

export { lightTheme, darkTheme };
