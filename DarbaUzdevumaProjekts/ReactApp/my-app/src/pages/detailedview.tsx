import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NewsPiece from "../../models/NewsPiece";
import { Box, Typography } from "@mui/material";
import NavBar from "./navbar";
import axios from "axios";




export default function DetailedView() {
    let {id} = useParams()
    const [theseNews, setTheseNews] = useState<NewsPiece>(); 


    useEffect(() => {
    axios.get<NewsPiece>('http://localhost:8004/api/News/GetNewsPiece/' +id).then(response => {
        setTheseNews(response.data)
        })
    }, []);
 

    return (
        <div>
            <NavBar/> 
            
            <Typography align= {"center"} sx={{ fontSize: 30 , fontWeight:'bold'}} color="text.secondary">
                {theseNews?.title}
            </Typography>
            
            <Typography align= {"justify"} style={{ marginLeft: 30, marginRight:30}} sx={{ fontSize: 20 }} color="text.secondary">
                {theseNews?.text}
            </Typography>
            
        </div>


    )






}