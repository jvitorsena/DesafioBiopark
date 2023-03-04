import * as React from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { NovoEdificio } from '../../Config/edificios';

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

export default function EdificiosNovoModal() {
    const [open, setOpen] = React.useState(false);
    const [nome, setNome] = React.useState<string>('');
    const [locadora, setLocadora] = React.useState<string>('');

    function register() {
        NovoEdificio(nome, locadora).then((response) => { window.location.reload(); }).catch((error) => console.log(error));
    }

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <Button onClick={handleOpen}>Novo edificio</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="parent-modal-title"
                aria-describedby="parent-modal-description"
            >
                <Box sx={{ ...style, width: 400 }}>
                    <div>
                        <TextField id="standard-basic" label="Nome" variant="standard" onChange={(e) => setNome(e.target.value)} />
                        <TextField id="standard-basic" label="Locadora" variant="standard" onChange={(e) => setLocadora(e.target.value)} />
                    </div>
                    <div className='mt-5'>
                        <Button onClick={() => register()}>Criar</Button>
                        {/* <ChildModal /> */}
                    </div>
                </Box>
            </Modal>
        </div>
    );
}
