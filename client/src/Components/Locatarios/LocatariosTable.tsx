import {
    Button,
    createStyles,
    IconButton,
    makeStyles,
    Paper,
    Snackbar,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Theme,
    Typography,
    TablePagination,
} from "@mui/material";
import ErrorModal from "../ErrorModal";

import { ITodosLocatarios, TodosLocatarios, LocatariosCabecalho, ExcluirLocatario } from "../../Config/locatarios"
import { Delete, Edit } from "@mui/icons-material";
import React, { useEffect, useState } from "react";
// import axios from 'axios';
// import moment from 'moment';
import { ThemeProvider, createTheme } from "@mui/material/styles";
import moment from "moment";
import { TrashIcon } from "../Icons";
import LocatarioEditModal from "./LocatarioEditModal";

const darkTheme = createTheme({
    typography: {
        fontSize: 14,
    },
    components: {},
    palette: {
        mode: "dark",
    },
});

interface props {
    values: Array<ITodosLocatarios>;
    quantityValues: number;
    setTodosEdificios: React.Dispatch<React.SetStateAction<Array<ITodosLocatarios>>>
}

export default function LocatariosTable(props: props) {
    const [open, setOpen] = React.useState(false);
    const [errMsg, setErrMsg] = React.useState('');
    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(10);

    const handleChangePage = (event: unknown, newPage: number) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement>
    ) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    function DeletarLocatario(id: number) {
        ExcluirLocatario(id).then(() => reload()).catch((error) => { setOpen(true), setErrMsg(error.response.data) });
    }

    const reload = async () => {
        await TodosLocatarios.then((json) => window.location.reload()).catch((error) =>
            console.log(error)
        );
        console.log("eoeo")
    }

    return (
        <>
            <ThemeProvider theme={darkTheme}>
                <ErrorModal open={open} setOpen={setOpen} errMsg={errMsg} />
                {/* <a className='cursor-pointer' onClick={() => teste2()}>saodjaoid</a> */}
                <TableContainer>
                    <Table>
                        <TableRow>
                            {LocatariosCabecalho.map((value) => (
                                <TableCell>{value}</TableCell>
                            ))}
                        </TableRow>
                        <TableBody>
                            {props.values
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map((value) => (
                                    <TableRow>
                                        <TableCell component="th" scope="row">
                                            {value.id}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.nome}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.dataNasc).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.createdAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.updatedAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.isActive ? "Ativo" : "Inativo"}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            <div className="flex flex-row items-center whitespace-nowrap text-right text-sm font-medium">
                                                <LocatarioEditModal id={value.id} dataNasc={value.dataNasc} nome={value.nome} />
                                                <a className="mx-1" href="#" onClick={() => DeletarLocatario(value.id)}>
                                                    {TrashIcon}
                                                </a>
                                            </div>
                                        </TableCell>
                                    </TableRow>

                                ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </ThemeProvider>
            <TablePagination
                rowsPerPageOptions={[10, 25, 100]}
                component="div"
                count={props.quantityValues}
                rowsPerPage={rowsPerPage}
                page={page}
                onPageChange={handleChangePage}
                onRowsPerPageChange={handleChangeRowsPerPage}
            />
        </>
    );
}
