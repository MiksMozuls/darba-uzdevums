import { useState } from "react";
import { useParams } from "react-router-dom";
import NewsPiece from "../../models/NewsPiece";
import { Box } from "@mui/material";
import NavBar from "./navbar";




export default function DetailedView() {
    let id = useParams()
    const [news, setNews] = useState<NewsPiece[]>([]); 

    return (
        <Box sx={{ flexGrow: 1 }}>
            <NavBar/> 
            
        </Box>


    )






}