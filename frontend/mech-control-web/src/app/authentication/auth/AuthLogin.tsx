"use client";

import React, { useState } from "react";
import {
  Box,
  Typography,
  FormGroup,
  FormControlLabel,
  Button,
  Stack,
  Checkbox,
  IconButton,
} from "@mui/material";
import Link from "next/link";
import {
  Password as PasswordIcon,
  Visibility as VisibilityIcon,
  VisibilityOff as VisibilityOffIcon,
  Email as EmailIcon,
} from "@mui/icons-material";
import CustomTextField from "@/app/components/forms/theme-elements/CustomTextField";

interface loginType {
  title?: string;
}

const AuthLogin = ({ title }: loginType) => {
  const [passwordVisible, setPasswordVisible] = useState(false);

  return (
    <>
      {title ? (
        <Typography fontWeight="700" variant="h2" mb={1}>
          {title}
        </Typography>
      ) : null}

      <Stack>
        <Box>
          <Typography
            variant="subtitle1"
            fontWeight={600}
            component="label"
            htmlFor="username"
            mb="5px"
          >
            E-mail
          </Typography>
          <CustomTextField
            id="email"
            type="email"
            InputProps={{
              startAdornment: <EmailIcon sx={{ paddingRight: "10px" }} />,
            }}
            variant="outlined"
            fullWidth
          />
        </Box>
        <Box mt="25px">
          <Typography
            variant="subtitle1"
            fontWeight={600}
            component="label"
            htmlFor="password"
            mb="5px"
          >
            Password
          </Typography>
          <CustomTextField
            id="password"
            type={passwordVisible ? "text" : "password"}
            variant="outlined"
            fullWidth
            InputProps={{
              startAdornment: <PasswordIcon sx={{ paddingRight: "10px" }} />,
              endAdornment: (
                <IconButton
                  aria-label="toggle password visibility"
                  edge="end"
                  onClick={() => setPasswordVisible((prev) => !prev)}
                >
                  {passwordVisible ? <VisibilityIcon /> : <VisibilityOffIcon />}
                </IconButton>
              ),
            }}
          />
        </Box>
        <Stack
          justifyContent="space-between"
          direction="row"
          alignItems="center"
          my={2}
        >
          <FormGroup>
            <FormControlLabel
              control={<Checkbox defaultChecked />}
              label="Manter-me conectado"
            />
          </FormGroup>
          <Typography
            component={Link}
            href="/"
            fontWeight="500"
            sx={{
              textDecoration: "none",
              color: "primary.main",
            }}
          >
            Esqueceu sua senha?
          </Typography>
        </Stack>
      </Stack>
      <Box>
        <Button
          color="primary"
          variant="contained"
          size="large"
          fullWidth
          component={Link}
          href="/"
          type="submit"
        >
          Entrar
        </Button>
      </Box>
    </>
  );
};

export default AuthLogin;
