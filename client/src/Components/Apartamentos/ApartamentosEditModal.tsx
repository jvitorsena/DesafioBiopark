import * as React from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { EditarApartamento } from '../../Config/apartamentos';
import { TodosEdificios, ITodosEdificios } from '../../Config/edificios';
import { useEffect } from 'react';
import MenuItem from '@mui/material/MenuItem';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3,
};

function ChildModal() {
    const [open, setOpen] = React.useState(false);

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };



    return (
        <React.Fragment>
            <Button onClick={handleOpen}>Open Child Modal</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="child-modal-title"
                aria-describedby="child-modal-description"
            >
                <Box sx={{ ...style, width: 200 }}>
                    <h2 id="child-modal-title">Text in a child modal</h2>
                    <p id="child-modal-description">
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                    </p>
                    <Button onClick={handleClose}>Close Child Modal</Button>
                </Box>
            </Modal>
        </React.Fragment>
    );
}

interface props {
    id: number;
    numero: number;
    andar: number;
    edificioId: number;
}

export default function ApartamentosEditModal(props: props) {
    const [open, setOpen] = React.useState(false);

    const [edificios, setEdificios] = React.useState<Array<ITodosEdificios>>([]);
    const [numero, setNumero] = React.useState<number>(props.numero);
    const [andar, setAndar] = React.useState<number>(props.andar);
    const [edificioId, setEdificioId] = React.useState<number>(props.edificioId);

    useEffect(() => {
        TodosEdificios.then((json) => setEdificios(json)).catch((error) =>
            console.log(error)
        );
        setEdificioId(props.edificioId);
    }, []);


    function Editar() {
        EditarApartamento(numero, andar, edificioId, props.id).then(() => window.location.reload()).catch((error) => console.log(error));
    }

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <a className="mx-1" href="#" onClick={handleOpen}>
                Edit
            </a>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="parent-modal-title"
                aria-describedby="parent-modal-description"
            >
                <Box sx={{ ...style, width: 400 }}>
                    <div>
                        <TextField type='number' id="standard-basic" value={numero} label="Numero" variant="standard" onChange={(e) => setNumero(Number(e.target.value))} />
                        <TextField type='number' id="standard-basic" value={andar} label="Andar" variant="standard" onChange={(e) => setAndar(Number(e.target.value))} />
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Edificios"
                            defaultValue="EUR"
                            helperText="Selecione o edificio"
                            onChange={(e) => setEdificioId(Number(e.target.value))}
                            value={edificioId}
                        >
                            {edificios.filter((value) => value.isActive === true).map((value) => (
                                <MenuItem key={value.id} value={value.id}>
                                    {value.nome}
                                </MenuItem>
                            ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <Button onClick={() => Editar()}>Salvar</Button>
                        {/* <ChildModal /> */}
                    </div>
                </Box>
            </Modal>
        </div>
    );
}
