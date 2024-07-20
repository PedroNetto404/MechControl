import Link from "next/link";
import { styled, Typography } from "@mui/material";

const LinkStyled = styled(Link)(() => ({
  height: "70px",
  width: "180px",
  overflow: "hidden",
  display: "block",
}));

const Logo = () => {
  return (
    <LinkStyled href="/">
      <Typography
        fontWeight={"bold"}
      >
        CSC Service Car
      </Typography>
    </LinkStyled>
  );
};

export default Logo;
