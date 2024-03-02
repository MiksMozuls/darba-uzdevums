import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NewsSource from "../../models/NewsSource";
import NewsPiece from "../../models/NewsPiece";
import axios from "axios";
import { Box, Grid, Paper, Typography, styled } from "@mui/material";
import NavBar from "./navbar";

const ArticlePaper = styled(Paper)(({ theme }) => ({
    width: 120,
    height: 120,
    padding: theme.spacing(2),
    margin: 20,
    ...theme.typography.body2,
    textAlign: 'center',
  }));
  

export default function FromSource() {
    let {id} = useParams(); 
    const [news, setNews] = useState<NewsPiece[]>(); 
    
    useEffect(() => {
        axios.get<NewsPiece[]>('http://localhost:8004/api/News/GetNewsFromSource/' + id).then(response => {
            setNews(response.data)
        })
    }, []);

    
    return (
        <div>
        <NavBar/>
    
        <Box sx={{ flexGrow: 1 }}>
        <Grid direction={'row'} container >
          
          {news?.map(x => (
            <div>
              
              <Grid item xs = {12} spacing={2}>
                        
          
                <ArticlePaper>
                  <Typography  component="a" href={`/detailed/${x.newsID}`} align= {"center"} sx={{ fontSize: 14 }} color="text.secondary">
                    {x.title.substring(0,50) + "..."}
                  </Typography>
                </ArticlePaper>
               
        
           
              </Grid>
               
    
            </div>
            
    
          ))}
     
          </Grid>
          </Box>
        </div>


    );

}

